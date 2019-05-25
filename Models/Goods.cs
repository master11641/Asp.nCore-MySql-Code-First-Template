using System;
namespace Inventory.Models
{
 public   enum ReciveType : Int32
    {
        FromState =1,
       BuyWithOffice = 2,
    }
    public class Goods
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ModifyDate { get; set; }=DateTime.Now;
        public Int64 Price{get;set;}
        public Int32 Count { get; set; }
        public ReciveType  ReciveType{ get; set; }
        public virtual Store Store { get; set; }
        public int StoreId { get; set; }
    }
}
