using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.ViewModels
{
   public class MetaKeyWordViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage="عنوان را وارد نمایید")]
        [StringLength(255)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
    }
}
