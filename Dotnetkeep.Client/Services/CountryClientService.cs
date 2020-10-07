using Dotnetkeep.Client.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetkeep.Client.Services
{
    public class CountryClientService : ClientServiceBase
    {


        public async Task<IEnumerable<Country>> GetAll()
        {
            return await this.ReadAsAsync<IEnumerable<Country>>("Countries");

        }

        public async Task<Country> GetByIsoCode(string isoCode)
        {


            return await this.ReadAsAsync<Country>("Countries/" + isoCode);



        }


    }
}
