using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogScover.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be 2 characters or longer")]
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "Decimal(10,2)")]
        public int Price { get; set; }
        public int CurrentFunding { get; set; }

        [Required]
        public int FundingGoal { get; set; }

        public int DonationAmount { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [Column(TypeName = "LONGTEXT")]
        public string ImageURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // -------------------Many to many----------------
        public List<Funder> Funders { get; set; }

        //--------------------One to Many----------------
        public User Creator { get; set; }
        public int UserId { get; set; }

    }
}