using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.ViewModels
{
   public class CityViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "شهر راه انتخاب کنید")]
        [StringLength(255)]
        [Display(Name = "انتخاب استان")]
        public string Title { get; set; }
    }
}
