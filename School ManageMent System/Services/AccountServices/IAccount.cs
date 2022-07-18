using Microsoft.AspNetCore.Identity;
using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem.Services.AccountServices
{
    public interface IAccount
    {
        public string getroleId(ApplicationUser User);
       
    }
}
