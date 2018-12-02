using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.ViewModels
{
   public class CommentViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="نام خود را وارد نمایید")]
        [MaxLength(255)]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage ="نظر خود را بنویسید")]
        [MaxLength(4000)]
        [Display(Name = "دیدگاه")]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "CreateDateTime")]
        public DateTime CreateDateTime { get; set; }
        public bool IsConfirm { get; set; }

    }
}
