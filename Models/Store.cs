using System;
using System.Collections;
using System.Collections.Generic;
namespace Inventory.Models
{
public class Store
{
      public Store(){
            Goodses = new HashSet<Goods>();
      }
     public int ID { get; set; }
     public string Name { get; set; }
     public string Address { get; set; }
     public ICollection<Goods> Goodses{get;set;}
      public DateTime ModifyDate { get; set; }=DateTime.Now;
}
}