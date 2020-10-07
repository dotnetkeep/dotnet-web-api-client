using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetkeep.Client.Entities
{
    public class Country : ClientEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string Currency { get; set; }
    }
}
