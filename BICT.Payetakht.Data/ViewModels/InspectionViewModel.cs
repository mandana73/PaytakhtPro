using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class InspectionViewModel
    {
        public int AuditID { get; set; }

        
        [Display(Name = "سازنده")]
        [Required(ErrorMessage ="سازنده را انتخاب نمایید")]
        public string CarManufactureTitle { get; set; }

        [Required(ErrorMessage ="مدل را انتخاب نمایید")]
        [Display(Name = "مدل")]
        public string CarModelTitle { get; set; }

        [Required(ErrorMessage ="سال را انتخاب نمایید")]
        [Display(Name = "سال ساخت")]
        public int CarYearTitle { get; set; }

        [Required(ErrorMessage ="جزئیات را وارد نمایید")]
        [Display(Name = "جزئیات")]
        public string CarDetailTitle { get; set; }

        [Required(ErrorMessage ="چکیده کارشناسی را وارد نمایید")]
        [Display(Name = "چکیده کارشناسی")]
        public string Description { get; set; }

        [Required(ErrorMessage ="رنگ را وارد نمایید")]
        [Display(Name = "رنگ")]
        public string Color { get; set; }

        [Required(ErrorMessage = "رنگ روکش را وارد نمایید")]
        [Display(Name = "روکش رنگ")]
        public string ColorType { get; set; }

        [Required(ErrorMessage = "تعداد دنده را وارد نمایید")]
        [Display(Name = "تعداد دنده")]
        [Range(1, 10)]
        public int GearBoxNumner { get; set; }

        [Required(ErrorMessage = "گیربکس  را وارد نمایید")]
        [Display(Name = "گیربکس")]
        public string GearBoxType { get; set; }

        [Required(ErrorMessage = "بدنه را وارد نمایید")]
        [Display(Name = "بدنه")]
        public string BodyType { get; set; }

        [Required(ErrorMessage = "کارکرد را وارد نمایید")]
        [Display(Name = "کارکرد")]
        [Range(0, int.MaxValue)]
        public int Usage { get; set; }

        [Required(ErrorMessage = "  حجم موتور را وارد نمایید ")]
        [Display(Name = "حجم موتور")]
        [Range(0, 10000)]
        public int EngineVolume { get; set; }

        [Required(ErrorMessage = " تعداد سیلندر را وارد نمایید")]
        [Display(Name = "تعداد سیلندر")]
        [Range(0, 10)]
        public int CylinderNumber { get; set; }

        [Required(ErrorMessage = " نوع سوخت را وارد نمایید")]
        [Display(Name = "نوع سوخت")]
        public string FuelType { get; set; }

        [Required(ErrorMessage = " وضعیت سقف را وارد نمایید")]
        [Display(Name = "سقف")]
        public string Roof { get; set; }

        [Required(ErrorMessage = " وضعیت صندوق عقب را وارد نمایید")]
        [Display(Name = "صندوق عقب")]
        public string Trunk { get; set; }

        [Required(ErrorMessage = "  وضعیت کاپوت را وارد نمایید")]
        [Display(Name = "کاپوت")]
        public string Hood { get; set; }

        [Required(ErrorMessage = " وضعیت در را وارد نمایید")]
        [Display(Name = "در جلو سمت شاگرد")]
        public string DoorRightFront { get; set; }

        [Required(ErrorMessage = " وضعیت در را وارد نمایید")]
        [Display(Name = "در جلو سمت راننده")]
        public string DoorLeftFront { get; set; }

        [Required(ErrorMessage = " وضعیت در را وارد نمایید")]
        [Display(Name = "در عقب سمت شاگرد")]
        public string DoorRightRear { get; set; }

        [Required(ErrorMessage = " وضعیت در را وارد نمایید")]
        [Display(Name = "در عقب سمت راننده")]
        public string DoorLeftRear { get; set; }

        [Required(ErrorMessage ="وضعیت ستون ها را وارد نمایید")]
        [Display(Name = "ستون جلو سمت شاگرد")]
        public string PillarRightFront { get; set; }


        [Required(ErrorMessage = "وضعیت ستون ها را وارد نمایید")]
        [Display(Name = "ستون جلو سمت راننده")]
        public string PillarLeftFront { get; set; }


        [Required(ErrorMessage = "وضعیت ستون ها را وارد نمایید")]
        [Display(Name = "ستون عقب سمت شاگرد")]
        public string PillarRightRear { get; set; }


        [Required(ErrorMessage = "وضعیت ستون ها را وارد نمایید")]
        [Display(Name = "ستون عقب سمت راننده")]
        public string PillarLeftRear { get; set; }

        [Required(ErrorMessage ="وضعیت گلگیر را وارد نمایید")]
        [Display(Name = "گلگیر جلو سمت شاگرد")]
        public string FenderRightFront { get; set; }

        [Required(ErrorMessage = "وضعیت گلگیر را وارد نمایید")]
        [Display(Name = "گلگیر جلو سمت راننده")]
        public string FenderLeftFront { get; set; }

        [Required(ErrorMessage = "وضعیت گلگیر را وارد نمایید")]
        [Display(Name = "گلگیر عقب سمت شاگرد")]
        public string FenderRightRear { get; set; }

        [Required(ErrorMessage = "وضعیت گلگیر را وارد نمایید")]
        [Display(Name = "گلگیر عقب سمت راننده")]
        public string FenderLeftRear { get; set; }

        [Required(ErrorMessage ="وضیت رکاب را وارد نمایید")]
        [Display(Name = "رکاب سمت شاگرد")]
        public string PedalRight { get; set; }

        [Required(ErrorMessage = "وضیت رکاب را وارد نمایید")]
        [Display(Name = "رکاب سمت راننده")]
        public string PedalLeft { get; set; }

        [Required(ErrorMessage ="وضعیت شاسی جلو را وارد نمایید")]
        [Display(Name = "شاسی جلو")]
        public string ChassisFront { get; set; }

        [Required(ErrorMessage = "وضعیت شاسی عقب را وارد نمایید")]
        [Display(Name = "شاسی عقب")]
        public string ChassisRear { get; set; }

        [Required(ErrorMessage ="وضعیت لاستیک جلو سمت شاگرد را وارد نمایید")]
        [Display(Name = "لاستیک جلو سمت شاگرد")]
        [Range(0, 100)]
        public int TireRightFront { get; set; }

        [Required(ErrorMessage = "وضعیت لاستیک عقب سمت راننده را وارد نمایید")]
        [Range(0, 100)]
        [Display(Name = "لاستیک عقب سمت راننده")]
        public int TireLeftFront { get; set; }

        [Required(ErrorMessage = "وضعیت لاستیک عقب سمت شاگرد را وارد نمایید")]
        [Range(0, 100)]
        [Display(Name = "لاستیک عقب سمت شاگرد")]
        public int TireRightRear { get; set; }

        [Required(ErrorMessage = "وضعیت لاستیک جلو سمت راننده را وارد نمایید")]
        [Range(0, 100)]
        [Display(Name = "لاستیک جلو سمت راننده")]
        public int TireLeftRear { get; set; }

        [Required(ErrorMessage = "وضعیت لاستیک زاپاس را وارد نمایید")]
        [Range(0, 100)]
        [Display(Name = "لاستیک زاپاس")]
        public int TireSpare { get; set; }

        public string CoverPic { get; set; }
        public IList<string> Pictures { get; set; }
    }
}
