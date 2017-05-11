using App3.SignUp;
using FacebookLogin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();

        }

       async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewReservation());
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["IsLoggedIn"] = false; // only gets set to 'true' on the LoginPage
           App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
