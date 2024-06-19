using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void ChangeRequest(string userId, string responsibleId)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetRequests()
        {
            throw new NotImplementedException();
        }

        public List<Request> GetResponsibleRequests(string responsibleId)
        {
            throw new NotImplementedException();
        }

        public void RemoveRequest(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
