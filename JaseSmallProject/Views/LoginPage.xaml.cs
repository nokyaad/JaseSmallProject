using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Identity.Client;
using JaseSmallProject.Models;
using System.Windows.Input;

namespace JaseSmallProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
            
        }



        protected override async void OnAppearing()
        {
            try
            {
                var accounts = await App.AuthenticationClient.GetAccountsAsync();
                if (accounts.Count() >=1)
                {
                    AuthenticationResult result = await App.AuthenticationClient
                        .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                        .ExecuteAsync();
                    if (result.IdToken.Length>1)
                    {
                        await Navigation.PushAsync(new ProtectedPage());
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
            catch
            {

            }
            base.OnAppearing();
        }



        private async void SigninBtn_Clicked(object sender, EventArgs e)
        {
            AuthenticationResult result;
            try
            {
                result = await App.AuthenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.ForceLogin)
                    .WithParentActivityOrWindow(App.UIParent)
                    .ExecuteAsync();
                await Navigation.PushAsync(new ProtectedPage());
            }
            catch (MsalClientException)
            {

            }
        }
    }
}