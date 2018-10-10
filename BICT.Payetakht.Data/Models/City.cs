namespace BICT.Payetakht.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
    }
}
