using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Identity.Client;
using System.Net.Http;
using Newtonsoft.Json;
using JaseSmallProject.Models;
using Xamarin.Essentials;

namespace JaseSmallProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private AuthenticationResult authenticationResult;
        public HomePage(AuthenticationResult result)
        {
            authenticationResult = result;
            InitializeComponent();
            BindingContext = this;
            
        }

        public async Task<IEnumerable<Charger>> getapi()
        {
            IEnumerable<Charger> flowerpot = null;
            string url = "https://testthingforxamarin.azurewebsites.net/api/test";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    flowerpot = JsonConvert.DeserializeObject<IEnumerable<Charger>>(content);
                }
            }
            return flowerpot;
        }


        public async Task<Charger> getprotectedapi()
        {
            Charger flowerpot = new Charger();
            string url = "https://testthingforxamarin.azurewebsites.net/api/test/1";
            HttpClient protectedClient = new HttpClient();
            protectedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
            using (protectedClient)
            {
                HttpResponseMessage response = await protectedClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Charger datalist = JsonConvert.DeserializeObject<Charger>(content);
                    flowerpot = datalist;
                }
            }
            return flowerpot;
        }


        private async void OpenApiBtn_Clicked(object sender, EventArgs e)
        {
            var protienshaker = await getapi();
            LabelAPi.Text = protienshaker.FirstOrDefault().Id;
        }

        private async void ProtectedBtn_Clicked(object sender, EventArgs e)
        {
            Charger protienshaker = await getprotectedapi();
            LabelAPi.Text = protienshaker.Location;

        }



        public IEnumerable<Charger> OpenApiList { get; set; } 


    }
}