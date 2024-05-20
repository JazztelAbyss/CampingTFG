using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _IService;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IService iService, ILogger<ServiceController> logger)
        {
            _IService = iService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Service>> GetServices()
        {
            return await Task.FromResult(_IService.GetServices());
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id) 
        {
            Service service = _IService.GetService(id);
            if(service != null)
            {
                return Ok(service);
            }
            return NotFound();
        }
    }
}
