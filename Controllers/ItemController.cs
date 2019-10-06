using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogScover.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DogScover.Controllers
{
    public class ItemController : Controller
    {
        private MyContext dbContext;
        public ItemController(MyContext context)
        {
            dbContext = context;
        }
        //--------------------------Show All Products ------------------------------/
        [HttpGet("allitems")]
        public IActionResult AllItems(string searchString)
        {
            int? SessionId = HttpContext.Session.GetInt32("SessionId");
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchresults = dbContext.Items.Where(p => p.Name.Contains(searchString)).ToList();
                var allfunders = dbContext.Items.Include(p => p.Funders).ToList();
                ViewBag.funders = allfunders;
                return View("AllItems", searchresults);
            }
            if (SessionId == null)
            {
                var allitems = dbContext.Items
                .Where(p => p.ItemId > 0)
                .OrderByDescending(made => made.CreatedAt)
                .ToList();
                var allfunders = dbContext.Items.Include(p => p.Funders).ToList();
                ViewBag.funders = allfunders;
                return View("AllItems", allitems);
            }
            else
            {
                var allitems = dbContext.Items
                .Where(p => p.ItemId > 0)
                .OrderByDescending(made => made.CreatedAt)
                .ToList();
                User UserInfo = dbContext.Users
                    .Include(idea => idea.CreatedItems)
                    .FirstOrDefault(account => account.UserId == (int)SessionId);
                ViewBag.Name = UserInfo.FirstName;
                var allfunders = dbContext.Items.Include(p => p.Funders).ToList();
                ViewBag.funders = allfunders;
                return View("AllItems", allitems);
            }
        }


        //-------------------------Show Specific Product CrowdFund------------------/

        [HttpGet("project/{id}")]
        public IActionResult ShowProject(int id)
        {
            int? SessionId = HttpContext.Session.GetInt32("SessionId");
            ViewBag.SessionId = SessionId;
            if (SessionId == null)
            {
                var ThisItem = dbContext.Items.FirstOrDefault(item => item.ItemId == id);
                return View("ShowProject", ThisItem);
            }
            var validuser = dbContext.Users.FirstOrDefault(u => u.UserId == SessionId);
            Item CurrentItem = dbContext.Items
            .Include(userwho => userwho.Creator)
            .Include(people => people.Funders)
                .ThenInclude(items => items.UsersFund)
            .FirstOrDefault(one => one.ItemId == id);
            ViewBag.Name = validuser.FirstName;
            return View("ShowProject", CurrentItem);

        }

        //------------------------Create a Project Page ----------------------------/
        [HttpGet("new/project")]
        public IActionResult ProjectForm()
        {
            int? SessionId = HttpContext.Session.GetInt32("SessionId");
            if (SessionId == null)
            {
                return View("LoginReg");
            }
            else
            {
                User UserInfo = dbContext.Users
                    .Include(idea => idea.CreatedItems)
                    .FirstOrDefault(account => account.UserId == (int)SessionId);
                ViewBag.Name = UserInfo.FirstName;
                return View("ProjectForm");
            }
        }

        [HttpPost("createproject")]
        public IActionResult CreateProject(Item NewProject)
        {
            int? SessionId = HttpContext.Session.GetInt32("SessionId");
            bool ItemInDb = dbContext.Items.Any(unique => unique.Name == NewProject.Name);
            if (ModelState.IsValid)
            {
                if (ItemInDb == true)
                {
                    ModelState.AddModelError("Name", "This Project Name Already Taken");
                    return RedirectToAction("ProjectForm");
                }
                else
                {
                    NewProject.UserId = (int)SessionId;
                    dbContext.Items.Add(NewProject);
                    dbContext.SaveChanges();
                    // Item ShowNewItem = dbContext.Items.FirstOrDefault(User => User.ItemId == NewProject.ItemId);
                    return RedirectToAction("AllItems");
                }
            }
            else
            {
                return View("ProjectForm");
            }
        }

        // ---------------Update Project--------------------------------------/

        [HttpGet("Edit/{id}")]
        public IActionResult EditProject(int id)
        {
            Item EditPage = dbContext.Items.FirstOrDefault(user => user.ItemId == id);
            int? SessionId = HttpContext.Session.GetInt32("SessionId");
            if (SessionId == null)
            {
                return RedirectToAction("ShowProject", EditPage);
            }
            else
            {
                if (EditPage == null)
                {
                    return RedirectToAction("ShowProject", EditPage);
                }
                else
                {
                    return View("UpdateItem", EditPage);
                }
            }
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateProject(Item info, int id)
        {
            Item update = dbContext.Items.FirstOrDefault(user => user.ItemId == id);
            if (update == null)
            {
                return RedirectToAction("EditProject", update);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    update.Name = info.Name;
                    update.Brand = info.Brand;
                    update.Price = info.Price;
                    update.CurrentFunding = info.CurrentFunding;
                    update.Description = info.Description;
                    update.ImageURL = info.ImageURL;
                    dbContext.SaveChanges();
                    return RedirectToAction("AllItems");
                }
                else
                {
                    return View("EditProject", update);
                }
            }
        }

        // ---------------Delete Project--------------------------------------/

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Item DeleteItem = dbContext.Items.FirstOrDefault(own => own.ItemId == id);
            dbContext.Items.Remove(DeleteItem);
            dbContext.SaveChanges();
            return RedirectToAction("HomePage", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // ------------Back a Project-------------------------------
        [HttpGet("backproject/{ItemId}")]
        public IActionResult BackProject(Funder backer)
        {
            int? SessionId = HttpContext.Session.GetInt32("SessionId");
            if (SessionId == null)
            {
                return View("LoginReg");
            }
            else
            {
                backer.UserId = (int)SessionId;
                dbContext.Funders.Add(backer);
                dbContext.SaveChanges();
                return RedirectToAction("AllItems");
            }
        }









    }
}

