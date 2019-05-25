using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using DNTPersianUtils;

namespace Inventory.Controllers
{
    public class HomeController : Controller
    {
        
    private readonly InventoryContext _ctx;

        public HomeController(InventoryContext ctx)
        {
            _ctx = ctx;
        }        public IActionResult Index()
        {
            InsertDate();
          //  GetDate();
       
          //  Console.Write("***"+GetDate().Count+"******");
            ViewData["count"] = GetDate().Count;
            return View();

        }
        private void InsertDate()
        {
           
                // Creates the database if not exists
                _ctx.Database.EnsureCreated();
                Store store= new Store()
                {
                    Name ="فروشگاه رخشنده",
                    Address = "بشرویه-بلوار انقلاب اسلامی",
                    
                };
                Goods goods = new Goods()
                {
                    Name = "15",
                };

                store.Goodses.Add(goods);
                _ctx.Store.Add(store);
                //_ctx.Goods.Add(goods);
                _ctx.SaveChanges();
           
        }
         private List<Goods> GetDate()
        {
            List<Goods> goods=new List<Goods>();
           
                goods = _ctx.Goods.ToList();
            
            return goods;
        }
        public IActionResult Privacy()
        {
            DateTime dt = DateTime.Now;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
