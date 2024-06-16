using DAL.Models;

namespace CampingWebAssembly.Services.Interfaces
{
	public interface IAuthenticationService
	{
		bool Login(string mail, string password);
		void Logout();
		bool IsLogged();
		User? GetLoggedUser();
	}
}
