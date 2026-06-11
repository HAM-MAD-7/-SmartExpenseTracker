using Microsoft.AspNetCore.Mvc;

namespace SmartExpenseTracker.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult BudgetLimit()
        {
            return View();
        }
    }
}
