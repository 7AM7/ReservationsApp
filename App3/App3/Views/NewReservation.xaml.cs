using App3.Models;
using App3.Services;
using App3.ViewModels;
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
    public partial class NewReservation : ContentPage
    {
        ReservationsViewModels viewModel;
        public NewReservation()
        {
            InitializeComponent();
            ClubNamePicker.Items.Add("Emirates Stadium");
            ClubNamePicker.Items.Add("Villa Park");
            ClubNamePicker.Items.Add("St. Andrew's Stadium");
            ClubNamePicker.Items.Add("Ewood Park");
            ClubNamePicker.Items.Add("Stamford Bridge");
            ClubNamePicker.Items.Add("Craven Cottage");
            ClubNamePicker.Items.Add("Anfield");
            ClubNamePicker.Items.Add("The City Ground");

            TimeFromPiker.Items.Add("5.PM");
            TimeFromPiker.Items.Add("7.PM");
            TimeFromPiker.Items.Add("9.PM");
            TimeFromPiker.Items.Add("11.PM");
            TimeFromPiker.Items.Add("1.AM");
            TimeFromPiker.Items.Add("3.AM");

            TimeToPiker.Items.Add("6.PM");
            TimeToPiker.Items.Add("8.PM");
            TimeToPiker.Items.Add("10.PM");
            TimeToPiker.Items.Add("12.AM");
            TimeToPiker.Items.Add("2.AM");
            TimeToPiker.Items.Add("4.AM");




            ClubNamePicker.Title = "Club....";
            TimeFromPiker.Title = "TimeFrom....";
            TimeToPiker.Title = "TimeTo....";
            BindingContext = viewModel = new ReservationsViewModels();

        }
        public NewReservation(ReservationsViewModels reservationsViewModels)
        {
            InitializeComponent();
            BindingContext = reservationsViewModels;
        }

        private void TimeToPiker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeToEntry.Text=TimeToPiker.Items[TimeToPiker.SelectedIndex];
        }

        private void TimeFromPiker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeFromEntry.Text = TimeFromPiker.Items[TimeFromPiker.SelectedIndex];
        }

        private void ClubNamePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClubEntry.Text = ClubNamePicker.Items[ClubNamePicker.SelectedIndex];
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            viewModel.IsBusy = true;
            var reservationsservices = new ReservationsServices();
            if (!(String.IsNullOrEmpty(ClubEntry.Text) || String.IsNullOrEmpty(TimeFromEntry.Text) || String.IsNullOrEmpty(TimeToEntry.Text)))
            {
                if(!String.IsNullOrEmpty(viewModel.StatusMassage))
                {
                    viewModel.StatusMassage = "";
                }
                var isSuccess = await reservationsservices.AddReservationsAsync(viewModel.SelectReservations);

                if ((isSuccess == true))
                {
                    viewModel.StatusMassage = "Add Successfully !";
                }
                else
                {
                    viewModel.StatusMassage = "Operation Add Failed !";
                }

            }
            else
                viewModel.StatusMassage = "Complate Chooses !";
            viewModel.IsBusy = false;
        }


    }
}
