using Autofac;
using demography.plugins.contracts.Repositories;
using demography.plugins.contracts.Repositories.Pollsters;
using demography.plugins.Repositories.MockDataRepo;
using demography.plugins.Repositories.RedisRepo;
using ServiceStack.Redis;

namespace demography.plugins.IocModules
{
    public class RepositoryModule : Module
    {
        public bool UseMockData { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (UseMockData)
            {
                builder.RegisterType<PollsterMockRepo>()
                       .As<IRepository<PollsterDto>>()
                       .SingleInstance();
            }
            else
            {
                var hosts = new string[] { @"9q+DzOgCni7JVKL7WyaM5hK9+WP1T1KJKW9ItKxXOUg=@demography.redis.cache.windows.net?ssl=true" };
                builder.RegisterType<PooledRedisClientManager>()
                       .As<IRedisClientsManager>()
                       .WithParameter("readWriteHosts", hosts)
                       .SingleInstance();

                builder.RegisterType<PollsterRedisRepo>()
                       .As<IRepository<PollsterDto>>()
                       .SingleInstance();
            }
        }
    }
}
