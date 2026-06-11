using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Data;
using SmartExpenseTracker.Models;

namespace SmartExpenseTracker.Controllers
{
    public class IncomeController : Controller
    {
        protected ApplicationDbContext _db;
        public IncomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult AddIncome()
        {
            var value = HttpContext.Session.GetInt32("UserId");
            if(value == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ReceiveAddIncome(IncomeModel income)
        {
            if(income.Amount > 0)
            {
                var value = HttpContext.Session.GetInt32("UserId");
                if (value != null)
                {
                    income.UserId = Convert.ToInt32(value);
                    _db.Add(income);
                    _db.SaveChanges();
                    return RedirectToAction("DisplayIncome");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                return RedirectToAction("ValidationIncome", "Validation");
            }
        }
        public IActionResult DisplayIncome()
        {
            var value = HttpContext.Session.GetInt32("UserId");
            if(value == null)
            {
                return RedirectToAction("Login", "User");
            }
            var amount = _db.Incomes.Where(inc => inc.UserId == value).ToList();
            return View(amount);
        }
        public IActionResult EditIncome(int Id)
        {
            var value = HttpContext.Session.GetInt32("UserId");
            var income = _db.Incomes.FirstOrDefault(inc => inc.IncomeId == Id && inc.UserId == value);
            if(income == null)
            {
                return Content("No Income Found!");
            }
            return View(income);
        }
        [HttpPost]
        public IActionResult ReceiveEditIncome(IncomeModel Income)
        {
            if(Income.Amount > 0)
            {
                var value = HttpContext.Session.GetInt32("UserId");
                var incomes = _db.Incomes.FirstOrDefault(inc => inc.IncomeId == Income.IncomeId && inc.UserId == value);
                if (incomes != null)
                {
                    incomes.Amount = Income.Amount;
                    incomes.Category = Income.Category;
                    incomes.Description = Income.Description;
                    incomes.Date = Income.Date;
                    _db.SaveChanges();
                }
                return RedirectToAction("DisplayIncome");
            }
            else
            {
                return RedirectToAction("ValidationEditIncome", "Validation");
            }
        }
        public IActionResult DeleteIncome(int Id)
        {
            var value = HttpContext.Session.GetInt32("UserId");
            var incomes = _db.Incomes.FirstOrDefault(inc => inc.IncomeId == Id && inc.UserId == value);
            if(incomes == null)
            {
                return Content("Income Not Found!");
            }
            else
            {
                _db.Remove(incomes);
                _db.SaveChanges();
            }
            return RedirectToAction("DisplayIncome");
        }
    }
}
