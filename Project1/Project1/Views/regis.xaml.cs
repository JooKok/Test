using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project1.Services;
namespace Project1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class regis : ContentPage
    {
        public regis()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Userdata data1;
            data1 = new Userdata
            {
                Username = user1.Text,
                Password = pass1.Text,
                Name = name1.Text,
                Surname = surname1.Text

            };

            //call AddUser function which we define in Firebase helper class    
            var user = await GoogleFirebase.AddUser(data1);
            if (user)
            {
                await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                Navigation.PushAsync(new login());
            }
        }
    }
}