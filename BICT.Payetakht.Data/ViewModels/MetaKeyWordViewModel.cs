using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.ViewModels
{
    public class MetaKeyWordViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(255)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
