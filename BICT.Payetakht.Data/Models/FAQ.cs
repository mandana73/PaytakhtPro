using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.Models
{
   public class FAQ
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Question { get; set; }

        [Required]
        [StringLength(4000)]
        public string Answer
        { get; set; }
    }
}
