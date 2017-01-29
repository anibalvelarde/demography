using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demography.api.Models
{
    public class PollsterMockData
    {
        private static volatile PollsterMockData instance;
        private static object syncRoot = new Object();
        private readonly List<Pollster> _pollsters = new List<Pollster>();

        private PollsterMockData()
        {
            _pollsters = new List<Pollster>() { new Pollster() { Name = "Anibal" }, new Pollster() { Name = "Lucas" } };
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

        private List<Pollster> Pollsters
        {
            get { return _pollsters; }
        }

        public IEnumerable<Pollster> GetAllPollsters()
        {
            return this.Pollsters;
        }

        public Pollster GetPollster(Guid id)
        {
            return Pollsters.FirstOrDefault(p => p.Id.Equals(id));
        }

        public bool AddPollster(Pollster p)
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

        public bool DeletePollster(Guid id)
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