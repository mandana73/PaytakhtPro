﻿namespace BICT.Payetakht.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarManufacturer
    {
        public CarManufacturer()
        {
            CarModels = new HashSet<CarModel>();
            Audits = new HashSet<Audit>();
            AuditTemps = new HashSet<AuditTemp>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
        public virtual ICollection<Audit> Audits { get; set; }
        public virtual ICollection<AuditTemp> AuditTemps { get; set; }
    }
}
