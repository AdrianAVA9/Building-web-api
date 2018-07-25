using ExpenseTracker.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Dtos
{
    public class ExpenseGroupStatusDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual HashSet<ExpenseGroup> ExpensesGroups { get; set; }
    }
}
