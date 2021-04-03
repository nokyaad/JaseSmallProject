using JaseSmallProject.ViewModels;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JaseSmallProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProtectedPage : ContentPage
    {

        public ProtectedPage()
        {
            InitializeComponent();
            BindingContext = new ProtectedApiCallViewModel();
        }


    }
}