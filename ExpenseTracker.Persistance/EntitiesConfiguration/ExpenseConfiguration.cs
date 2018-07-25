using ExpenseTracker.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.EntitiesConfiguration
{
    public class ExpenseConfiguration:EntityTypeConfiguration<Expense>
    {
        public ExpenseConfiguration()
        {
            Property(e => e.Description)
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.Amount)
                .HasPrecision(18,0);

            Property(e => e.Date)
                .HasColumnName("date");
        }
    }
}
