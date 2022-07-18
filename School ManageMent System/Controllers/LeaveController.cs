using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManageMentSystem.Models;
using SchoolManageMentSystem.Services.AppointmentServices;

namespace SchoolManageMentSystem.Controllers
{
    public class LeaveController : Controller
    {
        private readonly IAppointment _appointment;
        private readonly SchoolDbContext _schoolDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public LeaveController(UserManager<ApplicationUser> userManager
        , IAppointment appointment,SchoolDbContext sch)
        {
            _userManager = userManager;
            
            _appointment = appointment;
            _schoolDbContext = sch;

         }
        public IActionResult Index()
        {
            List<LeaveModel>leaves=_schoolDbContext.Leaves.ToList();
            return View(leaves);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LeaveModel model)
        {
            ApplicationUser currentuser = await _userManager.GetUserAsync(HttpContext.User);
            model.StudentId = currentuser.Id;

            _schoolDbContext.Add(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            LeaveModel model = _schoolDbContext.Leaves.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(LeaveModel model)
        {
            _schoolDbContext.Leaves.Update(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            LeaveModel model = _schoolDbContext.Leaves.FirstOrDefault(x=>x.Id == id);
            _schoolDbContext.Leaves.Remove(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
