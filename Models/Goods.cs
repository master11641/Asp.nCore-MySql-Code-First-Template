using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
 public   enum ReciveType : Int32
    {
       FromState =1,
       BuyWithOffice = 2,
       IsGift =3
    }
    public class Goods
    {
        [Display(Name="شناسه")]
        public int ID { get; set; }
          [Display(Name="عنوان کالا")]
        public string Name { get; set; }
          [Display(Name="تاریخ تغییر")]
        public DateTime ModifyDate { get; set; }=DateTime.Now;
          [Display(Name="تاریخ خرید")]
        public DateTime? BuyDate { get; set; }
          [Display(Name="قیمت")]
        public Int64 Price{get;set;}
          [Display(Name="تعداد خریداری شده")]
        public Int32 Count { get; set; } = 0;
          [Display(Name="")]
        public ReciveType  ReciveType{ get; set; }
          [Display(Name="")]
        public virtual Store Store { get; set; }
          [Display(Name="")]
        public int? StoreId { get; set; }
          [Display(Name="")]
        public string GiftedFrom { get; set; }
        //   [Display(Name="")]
        // public bool IsExist { get; set; }
          [Display(Name="")]
        public string BuyerName { get; set; }
          [Display(Name="")]
        public int? RegisterNumber {get;set;}
           [Display(Name="")]
        public virtual House House { get; set; }
          [Display(Name="")]
        public int? HouseId { get; set; }
    }
}
