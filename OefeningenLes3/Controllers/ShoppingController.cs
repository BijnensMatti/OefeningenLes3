using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OefeningenLes3.Entities;
using OefeningenLes3.Models;

namespace OefeningenLes3.Controllers
{
    //Scaffold-DbContext -Connection "Data Source=.\SQLEXPRESS;Initial Catalog=Shopping;Integrated Security=True;" -Provider 

    public class ShoppingController : Controller
    {
        private ShoppingContext db;
        private List<ShopItem> items = new List<ShopItem>();
        public ShoppingController()
        {
            db = new ShoppingContext();
            items.Add(new ShopItem { Name = "test", Amount = 5 });
            items.Add(new ShopItem { Name = "item2", Amount = 9 });
        }

        public ViewResult Index()
        {

            items = db.ShopItem.Select(c => c).ToList();
            return View(items);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(ShopItem item)
        {
            if (ModelState.IsValid)
            {
                items.Add(item);
                TempData["items"] = JsonConvert.SerializeObject(items);
                //TempData.Keep();
                return View("Finish", item);
            }
            else
            {
                return View(item);
            }
        }

        public ViewResult Find(string item, int? aantal)
        {
            return View("Index");
        }
    }
}