using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartExpenseTracker.Models
{
    public class ExpenseModel
    {
        [Key]
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        [ForeignKey (nameof(UserId))]
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
