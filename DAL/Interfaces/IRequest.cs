

using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRequest
    {
        public List<Request> GetRequests();
        public List<Request> GetResponsibleRequests(string responsibleId);
        public void AddRequest(Request request);
        public void RemoveRequest(string userId, string responsibleId);
        public void ChangeRequest(Request request);
    }
}
