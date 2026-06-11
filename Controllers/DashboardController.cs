using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Data;
using SmartExpenseTracker.ViewModel;

namespace SmartExpenseTracker.Controllers
{
    public class DashboardController : Controller
    {
        protected ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Dash()
        {
            Dashboard _dash = new Dashboard();
            var value = HttpContext.Session.GetInt32("UserId");
            if (value == null)
            {
                return RedirectToAction("Login", "User");
            }
            var name = _db.Users.FirstOrDefault(usr => usr.UserId == value);
            var total_inc = _db.Incomes.Where(usr => usr.UserId == value).Sum(s => s.Amount);
            var total_exp = _db.Expenses.Where(usr => usr.UserId == value).Sum(s => s.Amount);
            var balance = total_inc - total_exp;
            if (name != null)
            {
                _dash.FullName = name.FullName;
            }
            if(total_exp > total_inc)
            {
                balance = 0;
            }
            _dash.TotalIncome = total_inc;
            _dash.TotalExpense = total_exp;
            _dash.Balance = balance;
            return View(_dash);
        }
    }
}
