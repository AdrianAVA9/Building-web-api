using ExpenseTracker.Persistance.Entities;
using ExpenseTracker.Persistance.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance
{
    public class ExpenseGroupContext : DbContext
    {
        public DbSet<ExpenseGroupStatus> ExpenseGroupStatuses { get; set; }
        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpenseConfiguration());
            modelBuilder.Configurations.Add(new ExpenseGroupConfiguration());
            modelBuilder.Configurations.Add(new ExpenseGroupStatusConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
