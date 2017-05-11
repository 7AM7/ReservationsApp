using App3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App3.SignUp
{
   public class SignUpViewModels : INotifyPropertyChanged
    {
        private Account __selectdeletils= new Account();
        public Account SelectDetiles
        {
            get { return __selectdeletils; }
            set
            {
                __selectdeletils = value;
                OnPropertyChanged();
            }
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
