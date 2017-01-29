using demography.plugins.contracts.Repositories;
using demography.plugins.contracts.Repositories.Pollsters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demography.plugins.Repositories.Pollsters
{
    public class PollsterMockData : IRepository<PollsterDto>
    {
        private static volatile PollsterMockData instance;
        private static object syncRoot = new Object();
        private readonly List<PollsterDto> _pollsters = new List<PollsterDto>();

        public PollsterMockData()
        {
            _pollsters = new List<PollsterDto>() { new PollsterDto() { Id = Guid.NewGuid(), Name = "Anibal" }, new PollsterDto() { Id = Guid.NewGuid(), Name = "Lucas" } };
        }

        public static PollsterMockData Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new PollsterMockData();
                        }
                    }
                }
                return instance;
            }
        }

        private List<PollsterDto> Pollsters
        {
            get { return _pollsters; }
        }

        public IEnumerable<PollsterDto> GetAll()
        {
            return this.Pollsters;
        }

        public PollsterDto Get<Guid>(Guid id)
        {
            return Pollsters.FirstOrDefault(p => p.Id.Equals(id));
        }

        public bool Add(PollsterDto p)
        {
            try
            {
                Pollsters.Add(p);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete<Guid>(Guid id)
        {
            try
            {
                var pToDelete = Pollsters.First(p => p.Id.Equals(id));
                Pollsters.Remove(pToDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }        }
    }
}