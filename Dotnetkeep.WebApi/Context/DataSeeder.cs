using Dotnetkeep.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetkeep.WebApi.Context
{
    public static class DataSeeder
    {
        public static void Initialize(WebApiDbContext context)
        {
            context.Countries.AddRange
                (
                    new Country[]
                    {
                         new Country{ Id=1,Currency="EUR",Name="Italy", ISOCode="IT"},
                         new Country{ Id=2,Currency="BRL",Name="Brazil", ISOCode="BR" },
                         new Country{ Id=3,Currency="KRW",Name="South Korea", ISOCode="KR" },
                         new Country{ Id=4,Currency="EGP",Name="Egypt", ISOCode="EG" },
                    }
                );

            context.Cities.AddRange
              (
                  new City[]
                  {
                          new City{ Id=1,CountryId=1,Name="Milan"},
                          new City{ Id=2,CountryId=2,Name="Rio de Janeiro"},
                          new City{ Id=3,CountryId=2,Name="Recife"},
                          new City{ Id=4,CountryId=3,Name="Seoul"},
                          new City{ Id=5,CountryId=4,Name="Cairo"},
                  }
              );


            context.SaveChanges();
        }
    }
}
