using demography.plugins.contracts.Repositories;
using demography.plugins.contracts.Repositories.Pollsters;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demography.plugins.Repositories.RedisRepo
{
    sealed class PollsterRedisRepo : IRepository<PollsterDto>
    {
        private readonly IRedisClientsManager _redis;

        public PollsterRedisRepo(IRedisClientsManager redis)
        {
            _redis = redis;
        }

        private IRedisClientsManager RedisClientManager { get { return _redis; } }

        public bool Add(PollsterDto item)
        {
            using (var redis = RedisClientManager.GetClient())
            {
                var redisPollster = redis.As<PollsterDto>();
                redisPollster.Store(item);
                return true;
            }
        }

        public bool Delete<Guid>(Guid id)
        {
            using (var redis = RedisClientManager.GetClient())
            {
                var redisPollster = redis.As<PollsterDto>();
                var pollster = redisPollster.GetById(id);
                if (pollster == null) { return false; }
                redisPollster.DeleteById(id);
                return true;
            }
        }

        public PollsterDto Get<Guid>(Guid id)
        {
            using (var redis = RedisClientManager.GetClient())
            {
                return redis.As<PollsterDto>().GetById(id);
            }
        }

        public IEnumerable<PollsterDto> GetAll()
        {
            using (var redis = RedisClientManager.GetClient())
            {
                return redis.As<PollsterDto>().GetAll();
            }
        }
    }
}
