using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ExpenseTracker.Api.Autofac.Modules;
using ExpenseTracker.Dtos;
using ExpenseTracker.Persistance.Entities;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ExpenseTracker.Api.App_Start.Startup))]

namespace ExpenseTracker.Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            var autoMapperConfiguration = new AutoMapper.MapperConfiguration(configuration =>
            {
                configuration.CreateMap<ExpenseDto, Expense>();
                configuration.CreateMap<ExpenseGroupDto, ExpenseGroup>();
                configuration.CreateMap<ExpenseGroupStatusDto, ExpenseGroupStatus>();
                configuration.CreateMap<Expense, ExpenseDto>();
                configuration.CreateMap<ExpenseGroup, ExpenseGroupDto>();
                configuration.CreateMap<ExpenseGroupStatus, ExpenseGroupStatusDto>();
            });

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<ExpenseTrackerModule>();
            builder.RegisterInstance(autoMapperConfiguration.CreateMapper());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
