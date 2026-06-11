using System.ComponentModel.DataAnnotations;

namespace SmartExpenseTracker.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; } = "";
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public ICollection<ExpenseModel> Expenses { get; set; } = new List<ExpenseModel>();
        public ICollection<IncomeModel> Incomes { get; set; } = new List<IncomeModel>();
    }
}
