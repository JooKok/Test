using Project1.Models;
using Project1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Project1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class main : ContentPage
    {
        public IList<Job> data { get; private set; }
        public main()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            adddata();
            name.Text = Global.NameGlobal;
            surname.Text = Global.SurnameGlobal;
            username.Text = Global.UsernameGlobal;
        }
        public async void adddata()
        {
            var data = await GoogleFirebase.GetAllJob();
            var data1 = new ObservableCollection<Job>();
            int i = 0;
            for (i = 0; i < data.Count; i++) {
                if (Global.UsernameGlobal == data[i].username)
                {
                    data1.Add(data[i]);
                }
                    }
            listView.ItemsSource = data1;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addjob());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new login());
        }
    }
}