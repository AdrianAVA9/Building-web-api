using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.Entities
{
    public class ExpenseGroup
    {
        public ExpenseGroup()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExpenseGroupStatusId { get; set; }

        public virtual ExpenseGroupStatus ExpenseGroupStatus { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
