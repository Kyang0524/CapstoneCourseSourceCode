using CapstoneCourseAPI.Data;
using CapstoneCourseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace CapstoneCourseAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            List<Users> users = _db.Users.ToList();
            ViewBag.Users = users;
            return View();
        }

        [HttpPost("Store")]
        public IActionResult Store(String Name,String StudentId,String Email,String Department)
        {
            Users users = new Users();
            users.Name = Name;
            users.StudentId = StudentId;
            users.Email = Email;
            users.Department = Department;
            _db.Users.Add(users);
            _db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        [HttpPost("Delete")]
        public IActionResult Delete(String UserId)
        {
            Users users = _db.Users.Find(Convert.ToInt32(UserId))!;
            _db.Remove(users);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
