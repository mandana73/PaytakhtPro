using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BICT.Payetakht.Data.ViewModels
{
   public class FAQViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "پرسش خود را مطرح کنید")]
        [StringLength(1000)]
        [Display(Name = "پرسش")]
        public string Question { get; set; }

        [AllowHtml]
        [Required(ErrorMessage ="پاسخ را وارد نمایید")]
        [StringLength(4000)]
        [Display(Name = "پاسخ")]
        public string Answer { get; set; }
    }
}
