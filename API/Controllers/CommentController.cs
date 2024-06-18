using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly IComment _IComment;
		private readonly ILogger<CommentController> _Logger;

		public CommentController(IComment iComment, ILogger<CommentController> logger)
		{
			_IComment = iComment;
			_Logger = logger;
		}

		[HttpGet]
		public async Task<List<Comment>> GetComments()
		{
			return await Task.FromResult(_IComment.GetComments());
		}

		[HttpGet("{campingId}")]
		public async Task<List<Comment>> GetCampingComments(string campingId)
		{
			return await Task.FromResult(_IComment.GetCampingComments(campingId));
		}

		[HttpPost]
		public void AddComment(Comment comment)
		{
			_IComment.AddComment(comment);
		}

		[HttpDelete("{userId}/{campingId}")]
		public IActionResult DeleteComment(string userId, string campingId)
		{
			_IComment.RemoveComment(userId, campingId);
			return Ok();
		}

	}
}
