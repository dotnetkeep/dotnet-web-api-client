using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetkeep.WebApi.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string Currency { get; set; }
    }
}
