using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JaseSmallProject.Models
{
    public class ApiCalls
    {
        private HttpClient _httpClient;

        public ApiCalls()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Charger>> getapi()
        {
            IEnumerable<Charger> flowerpot = null;
            string url = "https://testthingforxamarin.azurewebsites.net/api/test";
            using (_httpClient)
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    flowerpot = JsonConvert.DeserializeObject<IEnumerable<Charger>>(json);
                }
            }
            return flowerpot;
        }

    }
}
