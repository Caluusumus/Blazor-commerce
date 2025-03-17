namespace Blazor_E_commerce.Services.UserServices;
 
using Blazor_E_commerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;

public class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    public IEnumerable<ApplicationUser> GetUsers()
    {
        return userManager.Users.ToList();
    }

    public ApplicationUser GetUser(int id)
    {
        var Id = id.ToString();
        return userManager.FindByIdAsync(Id).Result;
    }

    public void DeleteUser(int id)
    {
        string Id = id.ToString();
        userManager.DeleteAsync(userManager.FindByIdAsync(Id).Result);
    }

    public void UpdateUser(ApplicationUser user)
    {
        userManager.UpdateAsync(user);
    }
}
