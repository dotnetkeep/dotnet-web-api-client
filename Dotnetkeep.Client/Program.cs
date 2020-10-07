using Dotnetkeep.Client.Entities;
using Dotnetkeep.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetkeep.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            await GetAllCountries();
            await AddCity();
            await GetBrazilCities();
            await UpdateCity();
            await GetBrazilCities();
            await DeleteCity();
            await GetBrazilCities();



        }

        static async Task GetAllCountries()
        {
            CountryClientService service = new CountryClientService();


            IEnumerable<Country> result = await service.GetAll();

            System.Console.WriteLine("Country List");

            if (result.Any())
            {
                foreach (var item in result)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
        }
        static async Task GetBrazilCities()
        {
            CountryClientService countryService = new CountryClientService();
            CityClientService cityService = new CityClientService();


            Country country = await countryService.GetByIsoCode("BR");

            System.Console.WriteLine("Cities of Brazil");

            if (country != null)
            {
                IEnumerable<City> result = await cityService.GetByCountryId(country.Id);

                foreach (var item in result)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
        }

        static async Task AddCity()
        {
            try
            {
                City clientCity = new City { Id = 6, CountryId = 2, Name = "Sao Paolo" };
                CityClientService cityService = new CityClientService();

                var uri = await cityService.Add(clientCity);


                System.Console.WriteLine("Added city with uri:" + uri.AbsoluteUri);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


        }
        static async Task UpdateCity()
        {
            
            CityClientService cityService = new CityClientService();

            var city = await cityService.GetById(6);

            if (city!= null)
            {
                city.Name = "Sao Paulo";

                var httpStatusCode = await cityService.Update(city);

                if (httpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    System.Console.WriteLine("Updated City!");
                }

            }

        }

        static async Task DeleteCity()
        {

            CityClientService cityService = new CityClientService();

            var httpStatusCode = await cityService.Delete(6);

            if (httpStatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Console.WriteLine("Deleted City!");
            }

        }
    }
}
