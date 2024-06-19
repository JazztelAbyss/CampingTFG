using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class RequestManager : IRequest
    {

        readonly DBContext _dbContext = new();

        public RequestManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddRequest(Request request)
        {
            try
            {
                _dbContext.Requests.Add(request);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ChangeRequest(Request request)
        {
            try
            {
                _dbContext.Entry(request).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Request> GetRequests()
        {
            try 
            {
                return _dbContext.Requests.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Request> GetResponsibleRequests(string responsibleId)
        {
            try
            {
                return _dbContext.Requests.Where(r => r.ResponsibleId == responsibleId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveRequest(string userId, string responsibleId)
        {
            try
            {
                Request? r = _dbContext.Requests.Find(userId, responsibleId);
                if(r != null)
                {
                    _dbContext.Requests.Remove(r);
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
