using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ChefNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public List<Dish> CookedDishes { get; set; }
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public int CalculateAge()
        {
            int years = DateTime.Now.Year - this.Dob.Year;
            if((this.Dob.Month > DateTime.Now.Month) || (this.Dob.Month == DateTime.Now.Month && this.Dob.Day > DateTime.Now.Day))
                years--;
            return years;
        }

    }
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        [MinLength(1)]
        public string Dishname { get; set; }
        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }
        [Required]
        [MinLength(5)]
        public string Description { get; set; }
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public int ChefId { get; set; }
        public Chef Creator {get;set;}
    }
}