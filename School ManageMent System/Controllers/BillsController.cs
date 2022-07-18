using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManageMentSystem.Models;

namespace SchoolManageMentSystem.Controllers
{
    public class BillsController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public BillsController(SchoolDbContext schoolDbContext, UserManager<ApplicationUser> userManager)
        {
            _schoolDbContext = schoolDbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            List<BillsModel> bills = _schoolDbContext.Bills.ToList();
            return View(bills);
        }
        [HttpPost]
        public IActionResult AddBills(BillsModel model)
        {
            _schoolDbContext.Bills.Add(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AddBills()

        {
                       
            
            List<SelectListItem> users = (from u in await _userManager.GetUsersInRoleAsync("Student")
                                          select new SelectListItem { Text = u.UserName, Value = u.Id.ToString() }).ToList();
 
            
            ViewBag.Users = users;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            BillsModel model = _schoolDbContext.Bills.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(BillsModel model)
        {
            _schoolDbContext.Bills.Update(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            BillsModel model = _schoolDbContext.Bills.FirstOrDefault(x => x.Id == id);
            _schoolDbContext.Bills.Remove(model);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
