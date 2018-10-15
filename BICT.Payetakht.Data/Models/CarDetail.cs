namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarDetail
    {
        public CarDetail()
        {
            CarModelYearDetails = new HashSet<CarModelYearDetail>();
        }

        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual CarModel CarModel { get; set; }
        public ICollection<CarModelYearDetail> CarModelYearDetails { get; set; }
    }
}
