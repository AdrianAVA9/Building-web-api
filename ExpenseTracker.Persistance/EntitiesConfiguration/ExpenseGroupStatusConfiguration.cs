using ExpenseTracker.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistance.EntitiesConfiguration
{
    class ExpenseGroupStatusConfiguration : EntityTypeConfiguration<ExpenseGroupStatus>
    {
        public ExpenseGroupStatusConfiguration()
        {
            Property(egs => egs.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(egs => egs.Description)
                .HasMaxLength(50)
                .IsRequired();

            HasMany(egs => egs.ExpenseGroups)
                .WithRequired(egs => egs.ExpenseGroupStatus)
                .HasForeignKey(eg => eg.ExpenseGroupStatusId)
                .WillCascadeOnDelete(false);
        }
    }
}
