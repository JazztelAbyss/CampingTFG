using DAL.Models;

namespace DAL.Interfaces
{
    public interface IService
    {
        public List<Service> GetServices();
        public Service GetService(int id);
        public void PostService(Service service);
    }
}
