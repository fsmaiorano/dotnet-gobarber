using GoBarber.App.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoBarber.App.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        internal SignInViewModel ViewModel { get; set; } = Locator.Current.GetService<SignInViewModel>();

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}