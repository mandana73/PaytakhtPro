namespace BICT.Payetakht.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarYear
    {
        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }

        public int Year { get; set; }

        public virtual CarModel CarModel { get; set; }
    }
}
