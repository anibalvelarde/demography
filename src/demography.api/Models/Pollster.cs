using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demography.api.Models
{
    public class Pollster
    {
        public Pollster()
        {
            Id = Guid.NewGuid();
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