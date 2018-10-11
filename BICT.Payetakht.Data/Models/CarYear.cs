namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarYear
    {
        public CarYear()
        {
            CarDetails = new HashSet<CarDetail>();
        }

        [Key]
        public int ID { get; set; }

        public int CarModelID { get; set; }

        public int Year { get; set; }

        public virtual CarModels CarModels { get; set; }

        public ICollection<CarDetail> CarDetails { get; set; }
        public CarModels CarModel { get; internal set; }
    }
}
