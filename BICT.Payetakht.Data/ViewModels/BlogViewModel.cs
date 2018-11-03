using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BICT.Payetakht.Data.ViewModels
{
    public class BlogViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "عنوان را وارد نمایید")]
        [StringLength(255)]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "محتوا")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "CreateDateTime")]
        public DateTime CreateDateTime { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name ="خلاصه")]
        public string Summary { get; set; }
    }
}
