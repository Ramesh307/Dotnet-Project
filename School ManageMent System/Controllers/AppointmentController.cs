using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManageMentSystem.Models;
using SchoolManageMentSystem.Services.AppointmentServices;

namespace SchoolManageMentSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppointment _appointment;

        public AppointmentController(SchoolDbContext schoolDbContext, UserManager<ApplicationUser> userManager,IAppointment appointment )

        {
            _schoolDbContext = schoolDbContext;
            _userManager = userManager;
            _appointment = appointment;
           
        }
        public IActionResult Index()
        {
            List<AppointmentModel> appointments=_schoolDbContext.Appointments.ToList();
            return View(appointments);
        }
        [Authorize(Roles = "Guardian")]
        [HttpGet]
        public IActionResult Create()


        {
            List<SelectListItem> Department = _schoolDbContext.Departments.Select(x => new SelectListItem { Text = x.DName, Value = x.Id.ToString() }).ToList();
            ViewBag.Department = Department;
            return View();
        }
        [Authorize(Roles = "Guardian")]
        [HttpPost]
         
        public async Task<IActionResult>Create(AppointmentModel model)

        {
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(HttpContext.User);

            List<SelectListItem> Department = _schoolDbContext.Departments.Select(x => new SelectListItem { Text = x.DName, Value = x.Id.ToString() }).ToList();
            model.GuardianId = CurrentUser.Id;
            _appointment.Create(model);
            return RedirectToAction("/");
        }
        [Authorize (Roles ="Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            AppointmentModel model = _schoolDbContext.Appointments.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(AppointmentModel model)
        {
            _schoolDbContext.Appointments.Update(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            AppointmentModel model = _schoolDbContext.Appointments.FirstOrDefault(x => x.Id == id);
            _schoolDbContext.Appointments.Remove(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
