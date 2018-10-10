using System;

namespace BICT.Payetakht.Data
{
    public class BaseRepository : IDisposable
    {
        protected BICTDbContext db;

        public BaseRepository()
        {
            db = new BICTDbContext();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
