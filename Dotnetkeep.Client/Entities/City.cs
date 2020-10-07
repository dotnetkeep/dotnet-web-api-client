using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetkeep.Client.Entities
{
    public class City : ClientEntityBase
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

    }
}
