using System;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class AuditViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "سازنده را انتخاب کنید")]
        public int CarManufactureID { get; set; }

        [Display(Name = "سازنده")]
        public string CarManufactureTitle { get; set; }

        [Required(ErrorMessage = "مدل ماشین را انتخاب کنید")]
        public int CarModelID { get; set; }

        [Display(Name = "مدل")]
        public string CarModelTitle { get; set; }

        [Required(ErrorMessage = "سال ساخت را انتخاب نمایید")]
        public int CarYearID { get; set; }

        [Display(Name = "سال ساخت")]
        public int CarYearTitle { get; set; }

        [Required(ErrorMessage = "جزئیات را وارد کنید")]
        public int CarDetailID { get; set; }

        [Display(Name = "جزئیات")]
        public string CarDetailTitle { get; set; }

        [Required(ErrorMessage = "نام خود را وارد کنید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ایمیل  را وارد نمایید")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل خود را به درستی وارد نمایید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "تلفن را وارد کنید")]
        [Display(Name = "تلفن")]
        [RegularExpression(@"09\d\d\d\d\d\d\d\d\d", ErrorMessage = "تلفن را به درستی وارد نمایی.مثال: 09121234567")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "تاریخ را وارد کنید")]
        [Display(Name = "تاریخ درخواست")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "تاریخ را وارد کنید")]
        [Display(Name = "تاریخ درخواست")]
        [RegularExpression(@"\d\d\d\d/\d\d/\d\d", ErrorMessage = "تاریخ را به درستی وارد نمایی.مثال: 1397/01/01")]
        public string RequestDatePersian { get; set; }

        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [Display(Name = "هزینه کارشناسی")]
        public int Price { get; set; }

        [Display(Name = "خوانده شد")]
        public bool IsRead { get; set; }

        [Display(Name = "چک شد")]
        public bool IsDone { get; set; }

        public DateTime? PaymentDate { get; set; }
        public long? ReferID { get; set; }
        public string Authority { get; set; }
        public int? PaymentTypeID { get; set; }
    }
}
