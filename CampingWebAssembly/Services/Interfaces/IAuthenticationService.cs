using DAL.Models;

namespace CampingWebAssembly.Services.Interfaces
{
	public interface IAuthenticationService
	{
		bool Login(User user);
		void Logout();
		bool IsLogged();
		User? GetLoggedUser();
	}
}
