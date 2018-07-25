using ExpenseTracker.Persistance.Entities;
using ExpenseTracker.Persistance.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.Repositories
{
    public class ExpenseGroupRepository : IExpenseGroupRepository
    {
        private readonly ExpenseGroupContext _context;

        public ExpenseGroupRepository(ExpenseGroupContext context)
        {
            _context = context;
        }

        public RepositoryActionResult<ExpenseGroup> AddExpenseGroup(ExpenseGroup expenseGroup)
        {
            try
            {
                _context.ExpenseGroups
                    .Add(expenseGroup);

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.NothingModified);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<ExpenseGroup> EditExpenseGroup(ExpenseGroup expenseGroup)
        {
            try
            {
                var existingEG = _context.ExpenseGroups
                    .FirstOrDefault(eg => eg.Id == expenseGroup.Id);

                if (existingEG == null)
                {
                    return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.NotFound);
                }

                _context.Entry(existingEG).State = EntityState.Detached;

                _context.ExpenseGroups.Attach(expenseGroup);

                _context.Entry(expenseGroup).State = EntityState.Modified;

                var result = _context.SaveChanges();

                if (result == 0)
                    return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.NothingModified, null);
                else
                    return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.Updated);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ExpenseGroup>(expenseGroup, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<ExpenseGroup> DeleteExpenseGroup(int id)
        {
            try
            {
                var existingEG = _context.ExpenseGroups
                    .Where(eg => eg.Id == id)
                    .FirstOrDefault();

                if (existingEG != null)
                {
                    _context.ExpenseGroups.Remove(existingEG);
                    _context.SaveChanges();
                    return new RepositoryActionResult<ExpenseGroup>(null, RepositoryActionStatus.Deleted);
                }

                return new RepositoryActionResult<ExpenseGroup>(null, RepositoryActionStatus.NotFound,null);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<ExpenseGroup>(null,RepositoryActionStatus.Error,ex);
            }
        }

        public IQueryable<ExpenseGroup> GetExpensesGroups()
        {
            return _context.ExpenseGroups;
        }

        public ExpenseGroup GetExpenseGroup(int id, string userId)
        {
            return _context.ExpenseGroups
                .FirstOrDefault(eg => eg.Id == id && eg.UserId == userId);
        }

        public ExpenseGroup GetExpenseGroupWithExpenses(int id, string userId)
        {
            return _context.ExpenseGroups
                .Include(eg => eg.Expenses)
                .FirstOrDefault(eg => eg.Id == id && eg.UserId == userId);
        }

        public IQueryable<ExpenseGroup> GetExpensGroupsWithExpenses()
        {
            return _context.ExpenseGroups
                .Include(eg => eg.Expenses);
        }

        public ExpenseGroup GetExpenseGroup(int id)
        {
            return _context.ExpenseGroups.FirstOrDefault(eg => eg.Id == id);
        }
    }
}
