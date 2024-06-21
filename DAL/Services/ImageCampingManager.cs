using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ImageCampingManager : IImageCamping
    {
        readonly DBContext _dbContext = new();

        public ImageCampingManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ImageCamping> GetCampingImages(string CampingId)
        {
            try
            {
                return _dbContext.ImageCamping.Where(i => i.CampingId == CampingId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void PostCampingImage(ImageCamping image)
        {
            try
            {
                _dbContext.ImageCamping.Add(image);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
