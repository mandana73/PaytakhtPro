using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class InspectionViewModel
    {
        public int AuditID { get; set; }

        [Required]
        [Display(Name = "سازنده")]
        public string CarManufactureTitle { get; set; }

        [Required]
        [Display(Name = "مدل")]
        public string CarModelTitle { get; set; }

        [Required]
        [Display(Name = "سال ساخت")]
        public int CarYearTitle { get; set; }

        [Required]
        [Display(Name = "جزئیات")]
        public string CarDetailTitle { get; set; }

        [Required]
        [Display(Name = "چکیده کارشناسی")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "رنگ")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "روکش رنگ")]
        public string ColorType { get; set; }

        [Required]
        [Display(Name = "تعداد دنده")]
        [Range(1, 10)]
        public int GearBoxNumner { get; set; }

        [Required]
        [Display(Name = "گیربکس")]
        public string GearBoxType { get; set; }

        [Required]
        [Display(Name = "بدنه")]
        public string BodyType { get; set; }

        [Required]
        [Display(Name = "کارکرد")]
        [Range(0, int.MaxValue)]
        public int Usage { get; set; }

        [Required]
        [Display(Name = "حجم موتور")]
        [Range(0, 10000)]
        public int EngineVolume { get; set; }

        [Required]
        [Display(Name = "تعداد سیلندر")]
        [Range(0, 10)]
        public int CylinderNumber { get; set; }

        [Required]
        [Display(Name = "نوع سوخت")]
        public string FuelType { get; set; }

        [Required]
        [Display(Name = "سقف")]
        public string Roof { get; set; }

        [Required]
        [Display(Name = "صندوق عقب")]
        public string Trunk { get; set; }

        [Required]
        [Display(Name = "کاپوت")]
        public string Hood { get; set; }

        [Required]
        [Display(Name = "در جلو سمت شاگرد")]
        public string DoorRightFront { get; set; }

        [Required]
        [Display(Name = "در جلو سمت راننده")]
        public string DoorLeftFront { get; set; }

        [Required]
        [Display(Name = "در عقب سمت شاگرد")]
        public string DoorRightRear { get; set; }

        [Required]
        [Display(Name = "در عقب سمت راننده")]
        public string DoorLeftRear { get; set; }

        [Required]
        [Display(Name = "ستون جلو سمت شاگرد")]
        public string PillarRightFront { get; set; }

        [Required]
        [Display(Name = "ستون جلو سمت راننده")]
        public string PillarLeftFront { get; set; }

        [Required]
        [Display(Name = "ستون عقب سمت شاگرد")]
        public string PillarRightRear { get; set; }

        [Required]
        [Display(Name = "ستون عقب سمت راننده")]
        public string PillarLeftRear { get; set; }

        [Required]
        [Display(Name = "گلگیر جلو سمت شاگرد")]
        public string FenderRightFront { get; set; }

        [Required]
        [Display(Name = "گلگیر جلو سمت راننده")]
        public string FenderLeftFront { get; set; }

        [Required]
        [Display(Name = "گلگیر عقب سمت شاگرد")]
        public string FenderRightRear { get; set; }

        [Required]
        [Display(Name = "گلگیر عقب سمت راننده")]
        public string FenderLeftRear { get; set; }

        [Required]
        [Display(Name = "رکاب سمت شاگرد")]
        public string PedalRight { get; set; }

        [Required]
        [Display(Name = "رکاب سمت راننده")]
        public string PedalLeft { get; set; }

        [Required]
        [Display(Name = "شاسی جلو")]
        public string ChassisFront { get; set; }

        [Required]
        [Display(Name = "شاسی عقب")]
        public string ChassisRear { get; set; }

        [Required]
        [Display(Name = "لاستیک جلو سمت شاگرد")]
        [Range(0, 100)]
        public int TireRightFront { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "لاستیک عقب سمت راننده")]
        public int TireLeftFront { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "لاستیک عقب سمت شاگرد")]
        public int TireRightRear { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "لاستیک جلو سمت راننده")]
        public int TireLeftRear { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "لاستیک زاپاس")]
        public int TireSpare { get; set; }

        public string CoverPic { get; set; }
        public IList<string> Pictures { get; set; }
    }
}
