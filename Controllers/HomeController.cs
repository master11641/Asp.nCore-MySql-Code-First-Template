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
        }
        public IActionResult Index()
        {
            InsertDate();
            //  GetDate();

            //  Console.Write("***"+GetDate().Count+"******");
            ViewData["count"] = GetDate()[0].Name;
            return View();

        }
        private void InsertDate()
        {

            // Creates the database if not exists
            _ctx.Database.EnsureCreated();
            Store store = new Store()
            {
                Name = "فروشگاه رخشنده",
                Address = "بشرویه-بلوار انقلاب اسلامی",

            };
            House house = new House()
            {
                HeadName = "",
                HouseSituation = HouseSituation.New,
                HouseType = HouseType.QuranHouse,
                DocumentSituation = "",
                EarthSituation = "",
                Area = 0
            };

            Goods goods = new Goods()
            {
                Name = "یخچال",
                BuyDate = DateTime.Now,
                Count = 2,
                BuyerName = "",
                GiftedFrom = "",
              //  IsExist = true,
                ReciveType = ReciveType.BuyWithOffice,
                Price = 0,
                RegisterNumber = 125,

            };

            store.Goodses.Add(goods);
            house.Goodses.Add(goods);
            _ctx.Store.Add(store);
            
            _ctx.SaveChanges();

        }
        private List<Goods> GetDate()
        {
            List<Goods> goods = new List<Goods>();

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
