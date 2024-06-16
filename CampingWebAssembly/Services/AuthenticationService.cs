using CampingWebAssembly.Services.Interfaces;
using DAL;
using DAL.Models;

namespace CampingWebAssembly.Services
{
	public class AuthenticationService : IAuthenticationService
	{
		private User? LoggedUser = null;
		readonly DBContext _dbContext = new();

		public bool IsLogged()
		{
			return LoggedUser != null;
		}

		public bool Login(User user)
		{
            if (user != null)
			{
				LoggedUser = user;
				return true;
			}
			return false;
        }

		public void Logout()
		{
			LoggedUser = null;
		}

		public User? GetLoggedUser()
		{
			return LoggedUser;
		}
	}
}
