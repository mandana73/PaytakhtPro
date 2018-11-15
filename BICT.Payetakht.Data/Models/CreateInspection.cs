using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.Models
{
  public  class CreateInspection
    {

        [Key]
        public int ID { get; set; }

        public int CarManufactureID { get; set; }
        public int CarModelID { get; set; }
        public int CarYearID { get; set; }
        public int CarDetailID { get; set; }
    }
}
