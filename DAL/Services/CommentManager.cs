using DAL.Models;
using DAL.Interfaces;

namespace DAL.Services
{
	public class CommentManager : IComment
	{
		readonly DBContext _dbContext = new();

		public CommentManager(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddComment(Comment comment)
		{
			try
			{
				_dbContext.Comments.Add(comment);
				_dbContext.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

		public List<Comment> GetCampingComments(string campingId)
		{
			try
			{
				return _dbContext.Comments.Where(c => c.CampingId == campingId).ToList();
				
			}
			catch
			{
				throw;
			}
		}

		public List<Comment> GetComments()
		{
			try
			{
				return _dbContext.Comments.ToList();
			}
			catch
			{
				throw;
			}
			
		}

		public void RemoveComment(string userId, string campingId)
		{
			try
			{
				Comment? comment = _dbContext.Comments.Find(userId, campingId);
				if(comment != null)
				{
					_dbContext.Comments.Remove(comment);
					_dbContext.SaveChanges();
				}
				else
				{
					throw new ArgumentNullException();
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
