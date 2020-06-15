using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
     
        public HomeController(Context context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(chef => chef.CreatedDishes).ToList();
            return View(AllChefs);
        }

        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(dish => dish.Creator).ToList();
            return View(AllDishes);
        }

        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessAddChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Chefs.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddChef");
        }

        public IActionResult AddDish()
        {
            ViewBag.AllChefs = dbContext.Chefs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ProcessAddDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            return View("AddDish");
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
