using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CampingController : ControllerBase
    {
        private readonly ILogger<CampingController> _logger;

        public CampingController(ILogger<CampingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Campings")]
        public IEnumerable<Camping> GetCampingList()
        {
            
        }

        [HttpGet("Campings/{id}")]
        public Camping GetCamping(string id) 
        {
            return new Camping();
        }

        [HttpPost("Campings/Post")]
        public async Task UploadCamping(Camping camping)
        {

        }

        [HttpDelete("Campings/Delete/{id}")]
        public async Task DeleteCamping(string id)
        {

        }
    }
}
