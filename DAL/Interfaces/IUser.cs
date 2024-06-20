using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUser
    {
        public List<User> GetUsers();
        public User FindUserById(string id);
        public User FindUserByMail(string mail);
        public void RegisterUser(User user);
        public void UpdateUserInfo(User user);
        public void DeleteUser(string id);
    }
}
