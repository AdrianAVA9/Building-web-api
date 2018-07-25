using System.Linq;
using ExpenseTracker.Persistance.Entities;

namespace ExpenseTracker.Persistance.IRepositories
{
    public interface IExpenseRepository
    {
        RepositoryActionResult<Expense> Add(Expense expense);
        RepositoryActionResult<Expense> DeleteExpense(int id);
        Expense GetExpense(int id, int? expenseGroupId = null);
        IQueryable<Expense> GetExpenses();
        IQueryable<Expense> GetExpenses(int expenseGroupId);
        RepositoryActionResult<Expense> UpdateExpense(Expense expense);
    }
}