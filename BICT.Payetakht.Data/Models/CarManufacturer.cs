using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BICT.Payetakht.Data.Models
{
    public class CarManufacturer
    {
        public CarManufacturer()
        {
            CarModels = new HashSet<CarModel>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
