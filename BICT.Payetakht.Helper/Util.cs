using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BICT.Payetakht.Helper
{
    public static class Util
    {
        public static string RemoveMultiSpaces(string str, bool anySpace = false)
        {
            var pattern = string.Empty;
            if (anySpace)
            {
                pattern = @"[\s]{2,}";
            }
            else
            {
                pattern = @"[ ]{2,}";
            }
            var options = RegexOptions.None;
            var regex = new Regex(pattern, options);
            return regex.Replace(str, " ");
        }
    }
}
