using Microsoft.EntityFrameworkCore;
using MoneyTracker.Data;
using MoneyTracker.Models;

namespace MoneyTracker.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {

        private readonly AppDbContext _dbContext;

        public ExpenseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await _dbContext.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpense(int id)
        {
            return await _dbContext.Expenses.FindAsync(id);
        }

        public async Task<Expense> AddExpense(Expense expense)
        {
            var result = await _dbContext.Expenses.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Expense> UpdateExpense(Expense expense)
        {
            var selectedExpense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == expense.Id);

            if (selectedExpense == null)
            {
                return null;
            }

            selectedExpense.Id = expense.Id;
            selectedExpense.Name = expense.Name;
            selectedExpense.Amount = expense.Amount;
            selectedExpense.Description = expense.Description;

            await _dbContext.SaveChangesAsync();

            return selectedExpense;

        }

        public async void DeleteExpense(int id)
        {
            var selectedExpense = _dbContext.Expenses.FirstOrDefault(e => e.Id == id);
            if(selectedExpense == null)
            {
                return;
            }

            _dbContext.Remove(selectedExpense);
            await _dbContext.SaveChangesAsync();
        }

    }
}
