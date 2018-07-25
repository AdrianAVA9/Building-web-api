using System.Linq;
using ExpenseTracker.Persistance.Entities;

namespace ExpenseTracker.Persistance.IRepositories
{
    public interface IExpenseGroupStatusRepository
    {
        ExpenseGroupStatus GetExpenseGroupStatus(int id);
        IQueryable<ExpenseGroupStatus> GetExpenseGroupStatuses();
    }
}