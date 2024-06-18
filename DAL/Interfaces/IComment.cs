using DAL.Models;

namespace DAL.Interfaces
{
	public interface IComment
	{
		public List<Comment> GetComments();
		public List<Comment> GetCampingComments(string campingId);
		public void AddComment(Comment comment);
		public void RemoveComment(string userId, string campingId);
	}
}
