using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dotnetkeep.Client.Services
{
    public abstract class ClientServiceBase
    {
        public virtual string BaseUrl => @"https://localhost:44376/api/";

        HttpClient _client;


        protected HttpClient HttpApiClient
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                    _client.Timeout = new TimeSpan(0, 0, 30);
                    _client.BaseAddress = new Uri(BaseUrl);

                }

                return _client;
            }

        }



        protected virtual async Task<T> ReadAsAsync<T>(string path)
        {

            HttpResponseMessage response = await HttpApiClient.GetAsync(path);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }


        protected virtual async Task<Uri> PostAsAsync<T>(
             string path, T data)
        {

            var response = await HttpApiClient.PostAsJsonAsync(path, data);

            response.EnsureSuccessStatusCode();


            return response.Headers.Location;
        }

       

        protected virtual async Task<HttpStatusCode> PutAsAsync<T>(
         string path, T data)
        {

            var response = await HttpApiClient.PutAsJsonAsync(path, data);

            response.EnsureSuccessStatusCode();


            return response.StatusCode;
        }

        protected virtual async Task<HttpStatusCode> DeleteAsAsync(
        string path)
        {

            var response = await HttpApiClient.DeleteAsync(path);

            response.EnsureSuccessStatusCode();


            return response.StatusCode;
        }

    }



    }
