using Microsoft.AspNetCore.Identity;
using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem.Services.AccountServices
{
    public class AccountServices:IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountServices(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public string getroleId(ApplicationUser User)
        {
            string role = _userManager.GetRolesAsync(User).Result.FirstOrDefault();
            return role;
        }

    }
}
