namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarManufacturer
    {
        public CarManufacturer()
        {
            CarModels = new HashSet<CarModels>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual ICollection<CarModels> CarModels { get; set; }
    }
}
