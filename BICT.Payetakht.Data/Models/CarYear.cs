using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
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

        public virtual CarModel CarModels { get; set; }

        public ICollection<CarDetail> CarDetails { get; set; }
        public CarModel CarModel { get; internal set; }
    }
}
