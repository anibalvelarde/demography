using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using demography.plugins.contracts.Repositories.Pollsters;

namespace demography.api.Models
{
    public class Pollster
    {
        public Pollster()
        {
            Id = Guid.NewGuid();
        }

        public Pollster(PollsterDto p)
        {
            this.Id = p.Id;
            this.Name = p.Name;
        }

        private Pollster(Guid id)
        {
            Id = id;
        }


        public Guid Id
        {
            get;
            private set;
        }
        public string Name { get; set; }

        internal Pollster Update(Pollster value)
        {
            var p = new Pollster(this.Id);
            p.Name = value.Name;
            return p;
        }
    }
}