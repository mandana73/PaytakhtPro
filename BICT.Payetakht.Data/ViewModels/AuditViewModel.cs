using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class AuditViewModel
    {
        public int ID { get; set; }

        [Required]
        public int CarManufactureID { get; set; }

        [Display(Name = "سازنده")]
        public string CarManufactureTitle { get; set; }

        [Required]
        public int CarModelID { get; set; }

        [Display(Name = "مدل")]
        public string CarModelTitle { get; set; }

        [Required]
        public int CarYearID { get; set; }

        [Display(Name = "سال ساخت")]
        public int CarYear { get; set; }

        [Required]
        public int CarDetailID { get; set; }

        [Display(Name = "جزئیات")]
        public string CarDetailTitle { get; set; }

        [Required(ErrorMessage = "نام خود را وارد کنید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "تلفن را وارد کنید")]
        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "تاریخ را وارد کنید")]
        [Display(Name = "تاریخ درخواست")]
        public string Date { get; set; }
    }
}
