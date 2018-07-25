using System.Linq;
using ExpenseTracker.Persistance.Entities;

namespace ExpenseTracker.Persistance.IRepositories
{
    public interface IExpenseGroupRepository
    {
        RepositoryActionResult<ExpenseGroup> AddExpenseGroup(ExpenseGroup expenseGroup);
        RepositoryActionResult<ExpenseGroup> DeleteExpenseGroup(int id);
        ExpenseGroup GetExpenseGroup(int id, string userId);
        ExpenseGroup GetExpenseGroupWithExpenses(int id, string userId);
        IQueryable<ExpenseGroup> GetExpensesGroups();
        IQueryable<ExpenseGroup> GetExpensGroupsWithExpenses();
        RepositoryActionResult<ExpenseGroup> EditExpenseGroup(ExpenseGroup expenseGroup);
        object GetExpenseGroup(int id);
    }
}