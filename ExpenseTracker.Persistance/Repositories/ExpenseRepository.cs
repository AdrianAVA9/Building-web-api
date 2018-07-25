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
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseGroupContext _context;

        public ExpenseRepository(ExpenseGroupContext context)
        {
            _context = context;
        }

        public RepositoryActionResult<Expense> Add(Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);

                var result = _context.SaveChanges();

                if (result > 0)
                    return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.Created);

                return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.NothingModified,null);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.Error,ex);
            }
        }

        public RepositoryActionResult<Expense> UpdateExpense(Expense expense)
        {
            try
            {
                var existingE = _context.Expenses
                    .FirstOrDefault(e => e.Id == expense.Id);

                if (existingE == null)
                    return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.NotFound,null);

                _context.Entry(existingE).State = EntityState.Detached;

                _context.Expenses.Attach(expense);

                _context.Entry(expense).State = EntityState.Modified;

                var result = _context.SaveChanges();

                if (result > 0)
                    return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.Updated);

                return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.NothingModified,null);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Expense>(expense,RepositoryActionStatus.Error,ex);
            }
        }

        public RepositoryActionResult<Expense> DeleteExpense(int id)
        {
            var existingE = _context.Expenses
                .FirstOrDefault(e => e.Id == id);

            if (existingE == null)
                return new RepositoryActionResult<Expense>(null,RepositoryActionStatus.NotFound,null);

            _context.Expenses.Remove(existingE);

            var result = _context.SaveChanges();

            if (result > 0)
                return new RepositoryActionResult<Expense>(null, RepositoryActionStatus.Deleted);

            return new RepositoryActionResult<Expense>(null,RepositoryActionStatus.NothingModified,null);
        }

        public IQueryable<Expense> GetExpenses()
        {
            return _context.Expenses;
        }

        public Expense GetExpense(int id, int? expenseGroupId = null)
        {
            return _context.Expenses.
                FirstOrDefault(e => e.Id == id &&
                expenseGroupId ==  null || e.ExpenseGroupId == expenseGroupId);
        }

        public IQueryable<Expense> GetExpenses(int expenseGroupId)
        {
            var existingEG = _context.ExpenseGroups
                .FirstOrDefault(eg => eg.Id == expenseGroupId);

            if (existingEG == null)
                return null;

            return _context.Expenses
                .Where(e => e.ExpenseGroupId == existingEG.Id);
        }
    }
}
