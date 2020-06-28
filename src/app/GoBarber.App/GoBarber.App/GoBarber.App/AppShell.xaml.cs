using GoBarber.App.Views.Authentication;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoBarber.App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("registration", typeof(SignUp));
            Routing.RegisterRoute("main/login", typeof(SignIn));
            BindingContext = this;
        }

        public ICommand ExecuteLogout => new Command(async () => await GoToAsync("main/login"));
    }
}
