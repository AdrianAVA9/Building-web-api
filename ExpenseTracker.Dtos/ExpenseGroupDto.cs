using ExpenseTracker.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Dtos
{
    public class ExpenseGroupDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExpenseGroupStatusId { get; set; }

        public ExpenseGroupStatus ExpenseGroupStatus { get; set; }
        public HashSet<Expense> Expenses { get; set; }
    }
}
