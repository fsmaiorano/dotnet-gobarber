using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoBarber.App.Services;
using GoBarber.App.Views;

namespace GoBarber.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
