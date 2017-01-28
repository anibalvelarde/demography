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
    }
}