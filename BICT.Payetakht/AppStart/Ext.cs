using System.Linq;
using System.Web.Mvc;
using BICT.Payetakht.Data.Repository;

namespace BICT.Payetakht
{
    public static class Ext
    {
        public static string GetMetaKeyWord(this HtmlHelper html)
        {
            var repository = new MetaKeyWordRepository();
            var list = repository.GetList().Select(x => x.Title.Trim()).ToList();
            return string.Join(",", list);
        }
    }
}
