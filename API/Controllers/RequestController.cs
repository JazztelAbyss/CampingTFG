using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequest _IRequest;
        private readonly ILogger<RequestController> _Logger;

        public RequestController(IRequest iRequest, ILogger<RequestController> logger)
        {
            _IRequest = iRequest;
            _Logger = logger;
        }

        [HttpGet]
        public async Task<List<Request>> GetRequests()
        {
            return await Task.FromResult(_IRequest.GetRequests());
        }

        [HttpGet("{responsibleId}")]
        public async Task<List<Request>> GetResponsibleRequests(string responsibleId)
        {
            return await Task.FromResult(_IRequest.GetResponsibleRequests(responsibleId));
        }

        [HttpPost]
        public void AddRequest(Request request)
        {
            _IRequest.AddRequest(request);
        }

        [HttpDelete("{userId}/{responsibleId}")]
        public IActionResult DeleteRequest(string userId, string responsibleId)
        {
            _IRequest.RemoveRequest(userId, responsibleId);
            return Ok();
        }

        [HttpPut]
        public void ChangeRequest(Request request)
        {
            _IRequest.ChangeRequest(request);
        }

    }
}
