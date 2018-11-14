using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.ViewModels
{
  public  class PictureOfSlideViewModel
    {

        public int ID { get; set; }


        [Required(ErrorMessage = "افزودن عکس")]
        [Display(Name = "عکاسخانه")]
        public string PicturePath { get; set; }


    }
}
