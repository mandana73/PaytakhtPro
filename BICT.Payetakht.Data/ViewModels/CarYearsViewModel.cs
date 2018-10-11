using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class CarYearViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(255)]
        [Display(Name = "عنوان سازنده")]
        public int Year { get; set; }
    }
}
