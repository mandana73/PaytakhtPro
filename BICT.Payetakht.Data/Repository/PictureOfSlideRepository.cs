using System.Collections.Generic;
using System.Linq;
using BICT.Payetakht.Data.Models;
using BICT.Payetakht.Data.ViewModels;

namespace BICT.Payetakht.Data.Repository
{
    public class PictureOfSlideRepository : BaseRepository
    {
        public IList<PictureOfSlideViewModel> GetList()
        {
            return db.PictureOfSlides
                .Select(x => new PictureOfSlideViewModel
                {
                    ID = x.ID,
                    PicturePath = x.PicturePath,
                })
                .ToList();
        }

        public IList<PictureOfSlideViewModel> GetPagedList(int pageNum, int pageSize)
        {
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            var skip = (pageNum - 1) * pageSize;
            return db.PictureOfSlides
                     .OrderByDescending(x => x.ID)
                     .Skip(skip)
                     .Take(pageSize)
                     .Select(x => new PictureOfSlideViewModel
                     {
                         ID = x.ID,
                         PicturePath = x.PicturePath,
                     })
                     .ToList();
        }

        public PictureOfSlideViewModel GetItem(int id)
        {
            return db.PictureOfSlides.Where(x => x.ID == id)
                .Select(x => new PictureOfSlideViewModel
                {
                    ID = x.ID,
                    PicturePath = x.PicturePath,
                }).FirstOrDefault();
        }

        public void Create(string Path)
        {
            var item = new PictureOfSlide
            {
                PicturePath = Path,
            };
            db.PictureOfSlides.Add(item);
            db.SaveChanges();
        }

        public string Delete(int ID)
        {
            var a = db.PictureOfSlides.Find(ID);
            db.PictureOfSlides.Remove(a);
            db.SaveChanges();
            return a.PicturePath;
        }
    }
}
