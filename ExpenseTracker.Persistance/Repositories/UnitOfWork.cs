using ExpenseTracker.Persistance.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ExpenseGroupContext _context { get; private set; }
        public IExpenseGroupRepository ExpenseGroups { get; set; }
        public IExpenseRepository Expenses { get; set; }
        public IExpenseGroupStatusRepository ExpenseGroupStatuses { get; set; }

        public UnitOfWork()
        {
            _context = new ExpenseGroupContext();
            ExpenseGroups = new ExpenseGroupRepository(_context);
            Expenses = new ExpenseRepository(_context);
            ExpenseGroupStatuses = new ExpenseGroupStatusRepository(_context);
        }
    }
}
