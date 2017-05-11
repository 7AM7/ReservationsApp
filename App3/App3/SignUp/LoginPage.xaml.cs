using App3.Models;
using App3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        //ILoginManager ilm;
        public LoginPage()
        {
            InitializeComponent();
  
        }
        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            var usr = new Account
            {
                Name = NameLogin.Text,
                Password = PassLogin.Text
            };
            var isVaild = AreCredentialsCorrect(usr);

            if (String.IsNullOrEmpty(NameLogin.Text) || String.IsNullOrEmpty(PassLogin.Text) || !isVaild)
            {
                DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
            }
            else
            {
                App.Current.Properties["IsLoggedIn"] = true;
                App.Current.MainPage = new TabbedPage
                {
                Children =
                {
                    new NavigationPage(new ReservationsPage())
                    {
                        Title="Reservations"
                    },
                    new NavigationPage(new AccountPage())
                    {
                        Title="Account"
                    }
                }
                };
                // ilm.ShowMainPage();
            }

        }
        private async void SignupBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
        bool AreCredentialsCorrect(Account user)
        {
            return user.Name== "ahmed" && user.Password == "moorsy";
        }

    }
}