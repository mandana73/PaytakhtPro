namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        public CarModel()
        {
            CarYears = new HashSet<CarYear>();
        }

        [Key]
        public int ID { get; set; }

        public int CarManufacturerID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual CarManufacturer CarManufacturer { get; set; }
        public ICollection<CarYear> CarYears { get; set; }
    }
}
