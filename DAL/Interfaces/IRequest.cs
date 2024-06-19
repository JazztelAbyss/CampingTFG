

using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRequest
    {
        public List<Request> GetRequests();
        public List<Request> GetResponsibleRequests(string responsibleId);
        public void AddRequest(Request request);
        public void RemoveRequest(Request request);
        public void ChangeRequest(string userId, string responsibleId);
    }
}
