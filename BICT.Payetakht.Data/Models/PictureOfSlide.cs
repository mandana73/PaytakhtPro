using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class PictureOfSlide
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "افزودن عکس")]
        [Display(Name = "عکاسخانه")]
        [MaxLength(255)]
        public string PicturePath { get; set; }
    }
}
