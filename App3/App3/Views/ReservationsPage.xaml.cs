using App3.Models;
using App3.Services;
using App3.ViewModels;
using Plugin.Connectivity;
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
    public partial class ReservationsPage : ContentPage
    {
        ReservationsViewModels viewModel;

        public ReservationsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ReservationsViewModels();

        }

 		protected async  override void OnAppearing()
		{
            

            base.OnAppearing();
            // OnPropertyChanged();
            viewModel.IsBusy = true;
            var reservationsservices = new ReservationsServices();
            viewModel.ReservationsList = await reservationsservices.GetReservationsAsync();
            viewModel.IsBusy = false;
            // await DisplayAlert("Erorr!", "Check Your Connection !", "Ok");

            //if (CrossConnectivity.Current.IsConnected)
            //{
            //  //  viewModel.IsBusy = true;

            //    var reservationsservices = new ReservationsServices();
            //    viewModel.ReservationsList = await reservationsservices.GetReservationsAsync();
            //   // viewModel.IsBusy = false;
            //}
            //else
            //{
            //    await DisplayAlert("Erorr!", "Check Your Connection !", "Ok");
            //}

        }



        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewReservation());
        }

        private  async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var reservation = ReservaitionsList.SelectedItem as Reservations;
            if (reservation != null)
            {
                var reservationsViewModels = BindingContext as ReservationsViewModels;
                if(reservationsViewModels !=null)
                {
                    reservationsViewModels.IsBusy = true;
                    reservationsViewModels.StatusMassage=null;
                    reservationsViewModels.SelectReservations = reservation;

                  await  Navigation.PushAsync(new ItemPage(reservationsViewModels));
                   reservationsViewModels.IsBusy = false;
                }
            }

        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var reservationsViewModels = BindingContext as ReservationsViewModels;
            //reservationsViewModels.IsBusy = false;
           string keyword = SearchBar.Text;
            var reservationsservices = new ReservationsServices();
            viewModel.ReservationsList = await reservationsservices.GetReservationsByKeywordAsync(keyword);
            //reservationsViewModels.IsBusy = true;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var reservationsViewModels = BindingContext as ReservationsViewModels;
            var reservationsservices = new ReservationsServices();
            viewModel.IsBusy = true;
            viewModel.Keyword = SearchBar.Text;
            if (viewModel.Keyword != "")
            {
                
                viewModel.ReservationsList = await reservationsservices.GetReservationsByKeywordAsync(viewModel.Keyword);
            }
            else
            {
               // ReservaitionsList.ItemsSource = viewModel.ReservationsList;
                viewModel.ReservationsList = await reservationsservices.GetReservationsAsync();
            }
            viewModel.IsBusy =false;
        }
    }
}
