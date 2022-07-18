using Microsoft.AspNetCore.Identity;

namespace SchoolManageMentSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int DepartmentId { get; set; }


    }
}
