using App3.Models;
using App3.Services;

using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.ViewModels
{
   public class ReservationsViewModels :INotifyPropertyChanged
    {

        //private ObservableCollection<Reservations> _reservationsItems =new ObservableCollection<Reservations>();

        //public ObservableCollection<Reservations> ReservationsItems
        //{
        //    get { return this.ReservationsItems; }
        //set { ReservationsItems = value; }
        //}
        private List<Reservations> __reservationsList;
        private List<Reservations> __reservationsSearch;
        private Reservations __selectreservations = new Reservations();
        private bool _isBusy=false;
        private string _keyword;
        private string _status="a";

        private string _ClubName;
        private string _TimeFrom;
        private string _TimeTo;
        private string _StatusMassage;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        public string Keyword
        {
            get { return _keyword; }
            set {
                _keyword = value;
                OnPropertyChanged();
            }
        }

      
        public string ClubName
        {
            get { return _ClubName; }
            set
            {
                _ClubName = value;
                OnPropertyChanged();
            }
        }
        public string TimeFrom
        {
            get { return _TimeFrom; }
            set
            {
                _TimeFrom = value;
                OnPropertyChanged();
            }
        }
        public string TimeTo
        {
            get { return _TimeTo; }
            set
            {
                _TimeTo = value;
                OnPropertyChanged();
            }
        }
        public string StatusMassage
        {
            get { return _StatusMassage; }
            set
            {
                _StatusMassage = value;
                OnPropertyChanged();
            }
        }
        public List<Reservations> ReservationsList
        {
            get { return __reservationsList; }
            set
            {
                __reservationsList = value;
                OnPropertyChanged();
            }
        }
        public List<Reservations> ReservationsSearch
        {
            get { return __reservationsSearch; }
            set
            {
                __reservationsSearch = value;
                OnPropertyChanged();
            }
        }
        public Reservations SelectReservations
        {
            get { return __selectreservations; }
            set
            {
                __selectreservations = value;
                OnPropertyChanged();
            }
        }
       
        public Command AddCommand
        {
            get
            {
                return new Command( async() =>
                {

                        IsBusy = true;
                        var reservationsservices = new ReservationsServices();

                        var isSuccess = await reservationsservices.AddReservationsAsync(__selectreservations);

                        if ((isSuccess == true))
                        {
                            StatusMassage = "Add Successfully !";
                        }
                        else
                        {
                            StatusMassage = "Operation Add Failed !";
                        }


                });
            }
        }
        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var reservationsservices = new ReservationsServices();
                    var isSuccess=await reservationsservices.PutReservationsAsync(__selectreservations.Id, __selectreservations);
                    if (isSuccess == true)
                    {
                        StatusMassage = "Update Successfully !";
                    }
                    else
                    {
                        StatusMassage = "Operation Update Failed !";
                    }
                    IsBusy = false;
                });
            }
        }
        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var reservationsservices = new ReservationsServices();
                    var isSuccess = await reservationsservices.DeleteReservationsAsync(__selectreservations.Id);
                    if (isSuccess == true)
                    {
                        StatusMassage = "Delete Successfully !";
                    }
                    else
                    {
                        StatusMassage = "Operation Delete Failed !";
                    }
                    IsBusy = false;

                });
            }
        }

       public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    await InitializeDataAsync();
                    IsBusy = false;
                }
                );
            }
        }
        public Command SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var reservationsservices = new ReservationsServices();
                    await reservationsservices.GetReservationsByKeywordAsync(_keyword);
                });
            }
        }
        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value ?? string.Empty;
                    OnPropertyChanged();

                    // Perform the search
                    if (SearchCommand.CanExecute(null))
                    {
                        SearchCommand.Execute(null);
                    }
                }
            }
        }

        #region Command and associated methods for SearchCommand
        private Xamarin.Forms.Command _searchCommand;
        public System.Windows.Input.ICommand SearchCommandd
        {
            get
            {
                _searchCommand = _searchCommand ?? new Xamarin.Forms.Command(DoSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }
        private async  void DoSearchCommand()
        {
            IsBusy = true;
            // Refresh the list, which will automatically apply the search text
            var reservationsservices = new ReservationsServices();
            await reservationsservices.GetReservationsByKeywordAsync(_keyword);
            OnPropertyChanged();
            IsBusy = false;
            // RaisePropertyChanged(() => YourList);
        }
        private bool CanExecuteSearchCommand()
        {
            return true;
        }
        #endregion
        public ReservationsViewModels()
        {
            //var reservationsservices = new ReservationsServices();
            //ReservationsList = reservationsservices.GetReservations();
            InitializeDataAsync();
        }
        public async Task InitializeDataAsync()
        {
            IsBusy = true; 
            var reservationsservices = new ReservationsServices();
            ReservationsList = await reservationsservices.GetReservationsAsync();
            IsBusy = false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {

             var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
