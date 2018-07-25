using ExpenseTracker.Persistance.Entities;
using ExpenseTracker.Persistance.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.Repositories
{
    public class ExpenseGroupStatusRepository : IExpenseGroupStatusRepository
    {
        private readonly ExpenseGroupContext _context;

        public ExpenseGroupStatusRepository(ExpenseGroupContext context)
        {
            _context = context;
        }

        public ExpenseGroupStatus GetExpenseGroupStatus(int id)
        {
            return _context.ExpenseGroupStatuses
                .FirstOrDefault(egs => egs.Id == id);
        }

        public IQueryable<ExpenseGroupStatus> GetExpenseGroupStatuses()
        {
            return _context.ExpenseGroupStatuses;
        }
    }
}
