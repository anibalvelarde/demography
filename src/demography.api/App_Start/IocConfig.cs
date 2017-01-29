using Autofac;
using Autofac.Integration.WebApi;
using demography.plugins.contracts.Repositories;
using demography.plugins.contracts.Repositories.Pollsters;
using demography.plugins.Repositories.Pollsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace demography.api.App_Start
{
    public static class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PollsterMockData>().As<IRepository<PollsterDto>>().SingleInstance();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}