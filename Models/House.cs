using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Inventory.Models
{
    public enum HouseType : Int32
    {
        QuranHouse = 1,
        ScientistHouse = 2,
    }
    public enum HouseSituation : Int32
    {
        Old = 1,
        New = 2,
    }
    public class House
    {        
      public House(){
            Goodses = new HashSet<Goods>();
      }
        [Display(Name = "شناسه")]
        public int ID { get; set; }
        public HouseType HouseType { get; set; }
        public ICollection<Goods> Goodses { get; set; }
        public string EarthSituation { get; set; }
        public string DocumentSituation { get; set; }
        public HouseSituation HouseSituation { get; set; }
        public string HeadName { get; set; }
        public decimal? Area { get; set; }

    }
}