using MoneyTracker.Models;

namespace MoneyTracker.Repositories
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Expense>> GetAllExpenses();

        public Task<Expense> GetExpense(int id);

        public Task<Expense> AddExpense (Expense expense);

        public Task<Expense> UpdateExpense (Expense expense);

        public void DeleteExpense (int id);
    }
}
