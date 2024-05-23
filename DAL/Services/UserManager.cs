using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class UserManager : IUser
    {
        readonly DBContext _dbContext = new();

        public UserManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteUser(string id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
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

        public User FindUserByMail(string email)
        {
            try
            {
                User? user = _dbContext.Users.First(u => u.Mail.Equals(email));
                if (user != null)
                {
                    return user;
                }
                throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void RegisterUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUserInfo(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }           
        }
    }
}
