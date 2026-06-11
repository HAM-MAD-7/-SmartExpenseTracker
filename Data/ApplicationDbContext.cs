using Microsoft.EntityFrameworkCore;
using SmartExpenseTracker.Models;

namespace SmartExpenseTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<IncomeModel> Incomes { get; set; }
        public DbSet<ExpenseModel> Expenses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
