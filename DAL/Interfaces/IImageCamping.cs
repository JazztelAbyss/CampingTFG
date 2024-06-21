using DAL.Models;

namespace DAL.Interfaces
{
    public interface IImageCamping
    {
        public List<ImageCamping> GetCampingImages(string CampingId);
        public void PostCampingImage(ImageCamping image);
    }
}
