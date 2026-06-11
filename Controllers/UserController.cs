using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Data;
using SmartExpenseTracker.Models;

namespace SmartExpenseTracker.Controllers
{
    public class UserController : Controller
    {
        protected ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReceiveRegister(UserModel user)
        {
            var usr = _db.Users.FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
            if(usr != null)
            {
                return Content("UserName Or Email Already Exists!");
            }
            string hash_p = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hash_p;
            _db.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReceiveLogin(UserModel user)
        {
            var usr = _db.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if(usr != null && BCrypt.Net.BCrypt.Verify(user.Password, usr.Password))
            {
                HttpContext.Session.SetInt32("UserId",usr.UserId);
                return RedirectToAction("Dash", "Dashboard");
            }
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
