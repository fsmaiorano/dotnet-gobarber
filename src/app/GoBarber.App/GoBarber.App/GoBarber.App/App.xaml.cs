using GoBarber.App.Services.Authentication;
using GoBarber.App.Services.Routing;
using GoBarber.App.ViewModels;
using Splat;
using Xamarin.Forms;

namespace GoBarber.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeDi();
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private void InitializeDi()
        {
            // Services
            Locator.CurrentMutable.RegisterLazySingleton<IRoutingService>(() => new RoutingService());
            Locator.CurrentMutable.RegisterLazySingleton<IAuthenticationService>(() => new AuthenticationService());

            // ViewModels
            Locator.CurrentMutable.Register(() => new LoadingViewModel());
            Locator.CurrentMutable.Register(() => new SignInViewModel());
            Locator.CurrentMutable.Register(() => new SignUpViewModel());
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
