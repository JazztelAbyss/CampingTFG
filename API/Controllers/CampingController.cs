using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampingController : ControllerBase
    {
        private readonly ICamping _ICamping;
        private readonly ILogger<CampingController> _logger;

        public CampingController(ICamping ICamping, ILogger<CampingController> logger)
        {
            _ICamping = ICamping;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Camping>> GetCampingList()
        {
            return await Task.FromResult(_ICamping.GetCampings());
        }

        [HttpGet("{id}")]
        public IActionResult GetCamping(string id) 
        {
            Camping camping = _ICamping.GetCampingInfo(id);
            if(camping != null)
            {
                return Ok(camping);
            }
            return NotFound();
        }

        [HttpPost]
        public void UploadCamping(Camping camping)
        {
            _ICamping.AddCamping(camping);
        }

        [HttpPut]
        public void UpdateCamping(Camping camping)
        {
            _ICamping.UpdateCampingInfo(camping);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCamping(string id)
        {
            _ICamping.RemoveCamping(id);
            return Ok();
        }
    }
}
