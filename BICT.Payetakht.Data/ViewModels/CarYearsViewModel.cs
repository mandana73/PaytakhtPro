using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class CarYearViewModel
    {
        public int ID { get; set; }

        public string CarManufactureTitle { get; set; }

        [Required(ErrorMessage = "مدل ماشین را انتخاب نمایید")]
        public int CarModelID { get; set; }

        public string CarModelTitle { get; set; }

        [Required(ErrorMessage = "سال ساخت را وارد نمایید")]
        [Display(Name = "سال ساخت")]
        [Range(1350, 2020)]
        public int Year { get; set; }
    }
}
