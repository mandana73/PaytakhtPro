using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class CarYearViewModel
    {
        public int ID { get; set; }


        public string CarManufactureTitle { get; set; }

        public int CarModelID { get; set; }
        public string CarModelTitle { get; set; }

        [Required(ErrorMessage = "عنوان را وارد نمایید")]
        [Display(Name = "سال ساخت")]
        public int Year { get; set; }
    }
}
