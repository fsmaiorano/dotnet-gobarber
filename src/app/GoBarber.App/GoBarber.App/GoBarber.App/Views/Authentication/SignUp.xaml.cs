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
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        internal SignUpViewModel ViewModel { get; set; } = Locator.Current.GetService<SignUpViewModel>();
    }
}