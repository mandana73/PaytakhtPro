using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class CarModelYearDetail
    {
        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }
        public int CarYearID { get; set; }
        public int CarDetailID { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public virtual CarModel CarModel { get; set; }
        public virtual CarYear CarYear { get; set; }
        public virtual CarDetail CarDetail { get; set; }

        public int Price { get; set; }
    }
}
