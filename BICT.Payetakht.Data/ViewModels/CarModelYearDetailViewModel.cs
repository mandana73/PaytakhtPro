using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.ViewModels
{
   public class CarModelYearDetailViewModel
    {
        public int ID { get; set; }

       

        public int CarModelID { get; set; }
        public String CarModelTitle { get; set; }
        public int CarDetailID { get; set; }
        public String CarDetailTitle { get; set; }
        public int CarYearID { get; set; }
        public int CarYearTitle { get; set; }

       public int Price { get; set; }
    }
}
