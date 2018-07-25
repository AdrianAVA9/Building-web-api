using ExpenseTracker.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.EntitiesConfiguration
{
    public class ExpenseGroupConfiguration:EntityTypeConfiguration<ExpenseGroup>
    {
        public ExpenseGroupConfiguration()
        {
            Property(eg => eg.UserId)
                .HasMaxLength(100)
                .IsRequired();

            Property(eg => eg.Title)
                .HasMaxLength(50)
                .IsRequired();

            Property(eg => eg.Description)
                .HasMaxLength(250)
                .IsRequired();

            HasMany(e => e.Expenses)
                .WithRequired(e => e.ExpenseGroup)
                .WillCascadeOnDelete();
        }
    }
}
