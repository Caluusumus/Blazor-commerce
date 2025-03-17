using Blazor_E_commerce.Data;

namespace Blazor_E_commerce.Services.UserServices
{
    public interface IUserService
    {
        void DeleteUser(int id);
        ApplicationUser GetUser(int id);
        IEnumerable<ApplicationUser> GetUsers();
        void UpdateUser(ApplicationUser user);
    }
}