using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.Entities
{
    public class ExpenseGroupStatus
    {
        public ExpenseGroupStatus()
        {
            ExpenseGroups = new HashSet<ExpenseGroup>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExpenseGroup> ExpenseGroups { get; set; }
    }
}
