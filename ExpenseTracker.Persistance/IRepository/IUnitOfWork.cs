using ExpenseTracker.Persistance.IRepositories;

namespace ExpenseTracker.Persistance.IRepositories
{
    public interface IUnitOfWork
    {
        ExpenseGroupContext _context { get; }
        IExpenseGroupRepository ExpenseGroups { get; set; }
        IExpenseGroupStatusRepository ExpenseGroupStatuses { get; set; }
        IExpenseRepository Expenses { get; set; }
    }
}