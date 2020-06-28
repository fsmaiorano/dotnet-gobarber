using GoBarber.App.Services.Routing;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoBarber.App.ViewModels
{
    public class SignUpViewModel
    {
        private IRoutingService _navigationService;

        public SignUpViewModel(IRoutingService navigationService = null)
        {
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            ExecuteBack = new Command(() => Back());
            ExecuteRegistration = new Command(() => Register());
        }

        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand ExecuteBack { get; set; }
        public ICommand ExecuteRegistration { get; set; }

        private async void Back()
        {
            await _navigationService.GoBack();
        }

        private async void Register()
        {
            await _navigationService.NavigateTo("//main");
        }
    }
}
