using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JaseSmallProject.Models
{
    public class ProtectedApiCalls
    {
        private HttpClient _httpClient;
        private AuthenticationResult authenticationResult;

        public ProtectedApiCalls()
        {
            _httpClient = new HttpClient();
            
        }

        public async Task<Charger> getprotectedapi()
        {
            var accounts = await App.AuthenticationClient.GetAccountsAsync();
            if (accounts.Count() >= 1)
            {
                AuthenticationResult result = await App.AuthenticationClient
                    .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
                authenticationResult = result;
            }
            Charger flowerpot = new Charger();
            string url = "https://testthingforxamarin.azurewebsites.net/api/test/1";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
            using (_httpClient)
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Charger datalist = JsonConvert.DeserializeObject<Charger>(content);
                    flowerpot = datalist;
                }
            }
            return flowerpot;
        }
    }
}
