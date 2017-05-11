using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace App3.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void SignupBtn_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(NameSignup.Text) || String.IsNullOrEmpty(EmailSignup.Text)
                || String.IsNullOrEmpty(PasswordSignup.Text) || String.IsNullOrEmpty(ConfirmPasswordSignup.Text))
            {
                DisplayAlert("Validation Error", "Informations are required", "Re-Complate Informations");
            }else
            {
                
            }

        }
    }
}