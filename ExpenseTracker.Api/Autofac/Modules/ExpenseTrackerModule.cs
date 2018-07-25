using Autofac;
using ExpenseTracker.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Api.Autofac.Modules
{
    public class ExpenseTrackerModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().AsSelf();

            base.Load(builder);
        }
    }
}