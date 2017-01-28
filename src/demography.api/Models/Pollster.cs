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

        public Guid Id { get; private set; }
        public string Name { get; set; }
    }
}