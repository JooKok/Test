using Project1.Models;
using Project1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addjob : ContentPage
    {
        public addjob()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Job data1;
            data1 = new Job
            {
                username = Global.UsernameGlobal,
               customer = cus.Text,
               name = name.Text,
               date = date.Date.ToString("dd/MM/yyyy"),
               img = "home.png"
            };
            var user = await GoogleFirebase.AddJob(data1);
            //call AddUser function which we define in Firebase helper class    
           await DisplayAlert("Add Success", "", "Ok");
            Navigation.PushAsync(new main());
        }

        private void date_DateSelected(object sender, DateChangedEventArgs e)
        {
            var x = date.Date;
        }
    }
}