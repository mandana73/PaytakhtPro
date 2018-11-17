using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT.Payetakht.Data.ViewModels
{
   public class HomeViewModel
    {
     public   IList<PictureOfSlideViewModel> Slide { get; set; }
      public  IList<InspectionViewModel> Inspections { get; set; }
    }
}
