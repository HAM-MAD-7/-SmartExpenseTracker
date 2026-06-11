using Microsoft.AspNetCore.Mvc;

namespace SmartExpenseTracker.Controllers
{
    public class ValidationController : Controller
    {
        public IActionResult ValidationIncome()
        {
            return View();
        }
        public IActionResult ValidationExpense()
        {
            return View();
        }
        public IActionResult ValidationEditIncome()
        {
            return View();
        }
        public IActionResult ValidationEditExpense()
        {
            return View();
        }
    }
}
