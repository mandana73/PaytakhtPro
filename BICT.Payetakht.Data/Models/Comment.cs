using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.Models
{
   public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsConfirm { get; set; }
    }
}
