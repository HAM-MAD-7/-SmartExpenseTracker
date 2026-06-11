using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Data;
using SmartExpenseTracker.Models;

namespace SmartExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        protected ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult AddExpense()
        {
            var value = HttpContext.Session.GetInt32("UserId");
            if(value == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ReceiveAddExpense(ExpenseModel expense)
        {
            if(expense.Amount > 0)
            {
                var value = HttpContext.Session.GetInt32("UserId");
                var total_inc = _db.Incomes.Where(usr => usr.UserId == value).Sum(s => s.Amount);
                var total_exp = _db.Expenses.Where(usr => usr.UserId == value).Sum(s => s.Amount);
                if (total_exp + expense.Amount > total_inc)
                {
                    return RedirectToAction("BudgetLimit", "Budget");
                }
                if (value != null)
                {
                    expense.UserId = Convert.ToInt32(value);
                    _db.Add(expense);
                    _db.SaveChanges();
                    return RedirectToAction("DisplayExpense");
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                return RedirectToAction("ValidationExpense", "Validation");
            }
        }
        public IActionResult DisplayExpense()
        {
            var value = HttpContext.Session.GetInt32("UserId");
            if(value == null)
            {
                return RedirectToAction("Login", "User");
            }
            var expses = _db.Expenses.Where(exp => exp.UserId == value).ToList();
            return View(expses);
        }
        public IActionResult EditExpense(int Id)
        {
            var value = HttpContext.Session.GetInt32("UserId");
            var expses = _db.Expenses.FirstOrDefault(exp => exp.ExpenseId == Id && exp.UserId == value);
            if(expses == null)
            {
                return Content("No Expenses Found!");
            }
            return View(expses);
        }
        [HttpPost]
        public IActionResult ReceiveEditExpense(ExpenseModel expense)
        {
            if(expense.Amount > 0)
            {
                var value = HttpContext.Session.GetInt32("UserId");
                var expses = _db.Expenses.FirstOrDefault(exp => exp.ExpenseId == expense.ExpenseId && exp.UserId == value);
                
                if (expses != null)
                {
                    var total_inc = _db.Incomes.Where(usr => usr.UserId == value).Sum(s => s.Amount);
                    var total_exp = _db.Expenses.Where(usr => usr.UserId == value).Sum(s => s.Amount);
                    var NewTotalExpense = total_exp - expses.Amount + expense.Amount;
                    if (NewTotalExpense > total_inc)
                    {
                        return RedirectToAction("BudgetLimit", "Budget");
                    }
                    expses.Amount = expense.Amount;
                    expses.Category = expense.Category;
                    expses.Description = expense.Description;
                    expses.Date = expense.Date;
                    _db.SaveChanges();
                }
                return RedirectToAction("DisplayExpense");
            }
            else
            {
                return RedirectToAction("ValidationEditExpense", "Validation");
            }
        }
        public IActionResult DeleteExpense(int Id)
        {
            var value = HttpContext.Session.GetInt32("UserId");
            var expses = _db.Expenses.FirstOrDefault(exp => exp.ExpenseId == Id && exp.UserId == value);
            if(expses == null)
            {
                return Content("No Expenses Found!");
            }
            else
            {
                _db.Remove(expses);
                _db.SaveChanges();
            }
            return RedirectToAction("DisplayExpense");
        }
    }
}
