using System;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Required]
        [StringLength(1000)]
        public string Summary { get; set; }
    }
}
