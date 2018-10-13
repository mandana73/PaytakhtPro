namespace BICT.Payetakht.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarDetail
    {
        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}
