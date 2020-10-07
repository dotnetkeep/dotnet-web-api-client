using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotnetkeep.Client.Entities
{
    public class ClientEntityBase
    {
        public override string ToString()
        {
            return this.GetType().GetProperties()
                .Select(s => s.Name + ":" + s.GetValue(this).ToString())
                .Aggregate((f, s) => f + "|" + s);
        }
    }
}
