using App3.Services;
using App3.SignUp;
using App3.Views;
using FacebookLogin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public partial class App : Application
    {
        public static App Current;
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();
            Current = this;

           var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
            if (isLoggedIn)
                ShowMainPage();
            else
                MainPage = new NavigationPage(new LoginPage());


            //ShowMainPage();
            //MainPage = new NavigationPage(new ReservationsPage());
        }
        public void ShowMainPage()
        {
            Current.MainPage = new TabbedPage
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
                    },
                   new NavigationPage(new About())
                    {
                        Title="About"
                    }
                }
            };
        }


        public void Logout()
        {
            Properties["IsLoggedIn"] = false; // only gets set to 'true' on the LoginPage
            MainPage = new NavigationPage(new LoginPage());
        }
        //#region Azure stuff
        //static ReservationsManager reservationsManager;

        //public static ReservationsManager ReservationsoManager
        //{
        //    get { return reservationsManager; }
        //    set { reservationsManager = value; }
        //}

        //public static void SetReservationsManager(ReservationsManager ReservationsManager)
        //{
        //    ReservationsoManager = ReservationsManager;
        //}
        //#endregion
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
