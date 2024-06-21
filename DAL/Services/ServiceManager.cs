using DAL.Interfaces;
using DAL.Models;

namespace DAL.Services
{
    public class ServiceManager : IService
    {
        readonly DBContext _dbContext = new();

        public ServiceManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Service GetService(int id)
        {
            try
            {
                Service? service = _dbContext.Services.Find(id);
                if (service != null) 
                {
                    return service;
                }
                throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }

        public List<Service> GetServices()
        {
            try
            {
                return _dbContext.Services.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void PostService(Service service)
        {
            try
            {
                _dbContext.Services.Add(service);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
