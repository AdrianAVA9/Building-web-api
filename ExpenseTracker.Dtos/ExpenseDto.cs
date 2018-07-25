using ExpenseTracker.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public int ExpenseGroupId { get; set; }
        public virtual ExpenseGroup ExpenseGroup { get; set; }
    }
}
