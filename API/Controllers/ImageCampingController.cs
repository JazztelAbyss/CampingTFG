using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageCampingController : ControllerBase
    {
        private readonly IImageCamping _IImageCamping;
        private readonly ILogger<ImageCampingController> _Logger;

        public ImageCampingController(IImageCamping iImageCamping, ILogger<ImageCampingController> logger)
        {
            _IImageCamping = iImageCamping;
            _Logger = logger;
        }

        [HttpGet("{campingId}")]
        public async Task<List<ImageCamping>> GetCampingImages(string campingId)
        {
            return await Task.FromResult(_IImageCamping.GetCampingImages(campingId));
        }

        [HttpPost]
        public void PostCampingImage(ImageCamping imageCamping)
        {
            _IImageCamping.PostCampingImage(imageCamping);
        } 
    }
}
