namespace BICT.Payetakht.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarDetail
    {
        [Key]
        public int ID { get; set; }

        public int CarYearID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual CarYear CarYear { get; set; }
    }
}
