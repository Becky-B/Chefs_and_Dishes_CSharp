using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.AspNetCore.Identity;

namespace ChefsDishes.Controllers
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
            List<Chef> AllChefs = dbContext.Chefs.Include (c => c.CreatedDishs).ToList();
            return View(AllChefs);
        }
        [HttpGet("NewChef")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("AddChef")]
        public IActionResult AddChef(Chef fromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Chefs.Add(fromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef", fromForm);
            }
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include (d => d.Creator).ToList();
            return View(AllDishes);
        }
        [HttpGet("NewDish")]
        public IActionResult NewDish()
        {

            DishWrapper vmod = new DishWrapper();
            vmod.FormModel = new Dish();
            vmod.AllChefs = dbContext.Chefs.ToList();
            return View(vmod);
        }


        [HttpPost("AddDish")]
        public IActionResult AddDish(DishWrapper fromForm)
        {

            if(ModelState.IsValid)
            {
                System.Console.WriteLine("***************************************************");
                
                dbContext.Dishes.Add(fromForm.FormModel);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                fromForm.AllChefs = dbContext.Chefs.ToList();
                return View("NewDish", fromForm);
            }
        }
    }
}