using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogScover.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DogScover.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        //------------------------------Home Page ---------------------------/
        [HttpGet("")]
        public IActionResult HomePage()
        {
            int? sessionid = HttpContext.Session.GetInt32("SessionId");
            if (sessionid != null)
            {
                var validuser = dbContext.Users.FirstOrDefault(u => u.UserId == sessionid);
                ViewBag.Name = validuser.FirstName;
                return View("HomePage");
            }
            return View("HomePage");
        }

        //------------------------About the Company--------------------------/
        [HttpGet("about")]
        public IActionResult AboutTheCompany()
        {
            return View("AboutTheCompany");
        }

        //------------------------My Account Page ---------------------------/
        [HttpGet("account")]
        public IActionResult AccountSummary()
        {
            int? sessionId = HttpContext.Session.GetInt32("SessionId");
            if (sessionId == null)
            {
                return View("LoginReg");
            }
            else
            {
                var loggeduser = dbContext.Users
                .Include(idea => idea.CreatedItems).Include(item => item.FundedItems).ToList()
                .FirstOrDefault(account => account.UserId == (int)sessionId);



                ViewBag.Name = loggeduser.FirstName;
                return View("AccountSummary", loggeduser);
            }
        }

        //------------------------My Account Page /LoginReg--------------------/
        [HttpPost("register")]
        public IActionResult Register(User newuser)
        {
            if (ModelState.IsValid)
            {
                bool entry = dbContext.Users.Any(u => u.Email == newuser.Email);
                if (entry == true)
                {
                    ModelState.AddModelError("Email", "This email already exist in our systems");
                    return View("HomePage");
                }
                else
                {
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasLowerChar = new Regex(@"[a-z]+");
                    var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
                    var hasNumber = new Regex(@"[0-9]+");

                    if (!hasLowerChar.IsMatch(newuser.Password))
                    {
                        ModelState.AddModelError("Password", "Password must contain atleast one uppercase, lowercase, number, and symbol");
                        return View("LoginReg");
                    }
                    else if (!hasUpperChar.IsMatch(newuser.Password))
                    {
                        ModelState.AddModelError("Password", "Password must contain atleast one uppercase, lowercase, number, and symbol");
                        return View("LoginReg");
                    }
                    else if (!hasSymbols.IsMatch(newuser.Password))
                    {
                        ModelState.AddModelError("Password", "Password must contain atleast one uppercase, lowercase, number, and symbol");
                        return View("LoginReg");
                    }
                    else if (!hasNumber.IsMatch(newuser.Password))
                    {
                        ModelState.AddModelError("Password", "Password must contain  atleast one uppercase, lowercase, number, and symbol");
                        return View("LoginReg");
                    }
                    else
                    {
                        PasswordHasher<User> Hasher = new PasswordHasher<User>();
                        newuser.Password = Hasher.HashPassword(newuser, newuser.Password);
                        dbContext.Users.Add(newuser);
                        dbContext.SaveChanges();

                        //Session in User through here
                        HttpContext.Session.SetInt32("SessionId", newuser.UserId);
                        HttpContext.Session.SetString("UserName", newuser.FirstName);
                        return RedirectToAction("HomePage");
                    }
                }
            }
            else
            {
                return View("LoginReg");
            }
        }

        [HttpPost("signin")]
        public IActionResult Signin(LoginUser usersub)
        {
            if (ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == usersub.LoginEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginReg");
                }
                else
                {
                    PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(usersub, userInDb.Password, usersub.LoginPassword);
                    if (result == 0)
                    {
                        ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                        return View("LoginReg");
                    }
                    else
                    {
                        //Session User through here//
                        HttpContext.Session.SetInt32("SessionId", userInDb.UserId);
                        HttpContext.Session.SetString("UserName", userInDb.FirstName);
                        return RedirectToAction("HomePage");
                    }
                }
            }
            return View("LoginReg");
        }

        //------------------------Logout ---------------------------/

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("HomePage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
