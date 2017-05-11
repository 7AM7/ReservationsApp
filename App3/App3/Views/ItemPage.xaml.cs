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
    public partial class ItemPage : ContentPage
    {
        ReservationsViewModels viewModel;
        public ItemPage()
        {
            InitializeComponent();
        }
        public ItemPage(ReservationsViewModels reservationsViewModels)
        {
            InitializeComponent();
            BindingContext = reservationsViewModels;
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
            
          ///  ClubNamePicker.Title = "Club....";
          //  TimeFromPiker.Title = "TimeFrom....";
           // TimeToPiker.Title = "TimeTo....";
            viewModel = new ReservationsViewModels();
        }


        private void TimeToPiker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeToEntry.Text = TimeToPiker.Items[TimeToPiker.SelectedIndex];
        }

        private void TimeFromPiker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeFromEntry.Text = TimeFromPiker.Items[TimeFromPiker.SelectedIndex];
        }

        private void ClubNamePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClubEntry.Text = ClubNamePicker.Items[ClubNamePicker.SelectedIndex];
        }

    }
}
