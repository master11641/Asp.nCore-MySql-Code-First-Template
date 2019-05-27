using System.Linq;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inventory.Controllers
{
   public class MyProduct
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    public class AboutController : Controller
    {
        private readonly InventoryContext _ctx;

        public AboutController(InventoryContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            //ViewBag.DataSource = _ctx.Store.Select(x=>x.Name).ToList();
            return View();
        }
       public IEnumerable<MyProduct> GetProducts(string param1, string param2)
        {
            var products = new List<MyProduct>();
            for (var i = 1; i <= 100; i++)
            {
                products.Add(new MyProduct { Id = i, Name = "Product " + i });
            }
            return products;
        }
    }

}
