using Dotnetkeep.Client.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetkeep.Client.Services
{
    public class CityClientService : ClientServiceBase
    {
        public async Task<IEnumerable<City>> GetByCountryId(int id)
        {

            return await this.ReadAsAsync<IEnumerable<City>>("cities/countries/" + id.ToString());
        }

        public async Task<Uri> Add(City city)
        {
            return await this.PostAsAsync("cities/", city);

        }
        public async Task<HttpStatusCode> Update(City city)
        {
            return await this.PutAsAsync("cities/", city);

        }
        public async Task<City> GetById(int id)
        {
            return await this.ReadAsAsync<City>("cities/" + id.ToString());

        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            return await this.DeleteAsAsync("cities/" + id.ToString());

        }

    }
}
