using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
    }
}
