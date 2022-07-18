using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {

        // LOse coupling left
        private readonly SchoolDbContext _schoolDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DepartmentController(SchoolDbContext schoolDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)

        {
            _schoolDbContext = schoolDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            List<DepartmentModel>departmentList = _schoolDbContext.Departments.ToList();

            return View(departmentList);
        }
        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDepartment(DepartmentModel model)
        {
            _schoolDbContext.Departments.Add(model);
            _schoolDbContext.SaveChanges();
            return View("/");
        }
        [HttpGet]

        public IActionResult AssignDept()
        {
            List<SelectListItem> Department = _schoolDbContext.Departments.Select(x => new SelectListItem { Text = x.DName, Value = x.Id.ToString() }).ToList();
            // Add Query to filter only teachers
            List<SelectListItem> users = (from u in _userManager.Users 
                                          select new SelectListItem { Text = u.UserName, Value = u.Id.ToString() }).ToList();
            ViewBag.Department=Department;
            ViewBag.Users = users;
            return View();
        }
        [HttpPost]
        public async Task<string>AssignDept(UserModel model)
        {
            ApplicationUser user =await _userManager.FindByIdAsync(model.UserId);
            user.DepartmentId = model.DepartmentId;
            await _userManager.UpdateAsync(user);
            return user.DepartmentId.ToString();






        }
    }
}
