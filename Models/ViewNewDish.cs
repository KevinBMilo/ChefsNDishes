using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;

namespace ChefNDishes.Models
{
    public class ViewNewDish
    {
        public Chef NewChef {get;set;}
        public List<Chef> AllChefs {get;set;}
        public Dish NewDish {get;set;}
        public List<Dish> AllDishes {get;set;}
        public int ChefId { get; set; }
        public Chef Creator {get;set;}
    }
}