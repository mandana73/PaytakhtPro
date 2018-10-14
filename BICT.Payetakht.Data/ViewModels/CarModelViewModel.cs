using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class CarModelViewModel
    {
        public int ID { get; set; }

        public int CarManufacturerID { get; set; }
        public string CarManufactureTitle { get; set; }
        

        [Required(ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(255)]
        [Display(Name = "عنوان مدل")]
        public string Title { get; set; }
    }
}
