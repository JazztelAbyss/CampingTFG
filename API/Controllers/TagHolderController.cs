using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagHolderController : ControllerBase
    {
        private readonly ITagHolder _ITagHolder;
        private readonly ILogger<TagHolderController> _Logger;

        public TagHolderController(ITagHolder iTagHolder, ILogger<TagHolderController> logger)
        {
            _ITagHolder = iTagHolder;
            _Logger = logger;
        }

        [HttpGet("{campingId}")]
        public async Task<List<TagHolder>> GetCampingTags(string campingId)
        {
            return await Task.FromResult(_ITagHolder.GetCampingTags(campingId));
        }

        [HttpPost]
        public void PostTagHolder(TagHolder tagHolder)
        {
            _ITagHolder.PostCampingTag(tagHolder);
        }
    }
}
