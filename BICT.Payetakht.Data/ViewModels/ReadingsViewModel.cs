﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BICT.Payetakht.Data.ViewModels
{
  public  class ReadingsViewModel
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
    }
}
