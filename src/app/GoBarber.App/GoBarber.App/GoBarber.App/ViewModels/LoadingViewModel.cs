using GoBarber.App.Services.Authentication;
using GoBarber.App.Services.Routing;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.App.ViewModels
{
    class LoadingViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly IAuthenticationService authenticationService;

        public LoadingViewModel(IRoutingService routingService = null, IAuthenticationService authenticationService = null)
        {
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.authenticationService = authenticationService ?? Locator.Current.GetService<IAuthenticationService>();
        }

        // Called by the views OnAppearing method
        public async void Init()
        {
            var isAuthenticated = await this.authenticationService.VerifyRegistration();
            if (isAuthenticated)
            {
                await this.routingService.NavigateTo("///main");
            }
            else
            {
                await this.routingService.NavigateTo("///login");
            }
        }
    }
}
