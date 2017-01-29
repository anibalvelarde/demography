using Autofac;
using Autofac.Integration.WebApi;
using demography.plugins.IocModules;
using System.Reflection;
using System.Web.Http;

namespace demography.api.App_Start
{
    public static class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new RepositoryModule() { UseMockData = false });

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}