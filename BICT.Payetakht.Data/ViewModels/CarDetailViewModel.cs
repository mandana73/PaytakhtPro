using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class CarDetailViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "جزئیات را وارد نمایید")]
        [Display(Name = "جزئیات")]
        [StringLength(255)]
        public string Title { get; set; }

        public int CarModelID { get; set; }
        public string CarModelTitle { get; set; }
    }
}
