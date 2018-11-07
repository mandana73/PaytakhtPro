using System.IO;
using System.Text.RegularExpressions;

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

        public static bool CheckFormat(string fileName, params string[] formats)
        {
            var ext = Path.GetExtension(fileName);
            foreach (var format in formats)
            {
                var frmt = format.Trim();
                if (frmt.StartsWith(".") == false)
                {
                    frmt = "." + format;
                }
                if (ext.ToLower() == frmt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
