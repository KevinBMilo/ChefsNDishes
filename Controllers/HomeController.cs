using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;



namespace ChefNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }



        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
                .Include(chef => chef.CookedDishes)
                .ToList();
            return View("Index", AllChefs);
        }
        return View("Index");

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("New");
        }

        [HttpGet("dishes")]
        public IActionResult GetDishes(int DishId)
        {
            List<Dish> AllDishes = dbContext.Dishes
                .Include(dish => dish.Creator)
                .ToList();
            return View("All", AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewNewDish ViewToHtml = new ViewNewDish()
            {
                AllChefs = dbContext.Chefs.ToList()
            };
            return View("Newdish", ViewToHtml);
        }

        [HttpPost("hire")]
        public IActionResult Hire(Chef newChef)
        {
            Chef submittedChef = newChef;
            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index", newChef);
            }
            return View("New");
        }

        [HttpPost("cook")]
        public IActionResult Cook(Dish newDish)
        {
            Dish submittedDish = newDish;
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("GetDishes", newDish);
            }
            return View("Newdish");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
