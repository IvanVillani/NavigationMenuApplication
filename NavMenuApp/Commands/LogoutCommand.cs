using NavMenuApp.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using NavMenuApp.ViewModels;
using NavMenuApp.Services;


namespace NavMenuApp.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly AccountStore _accountStore;
        private readonly INavigationService<HomeViewModel> _navigationService;

        public LogoutCommand(AccountStore accountStore, INavigationService<HomeViewModel> navigationService)
        {
            _accountStore = accountStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _accountStore.Logout();

            _navigationService.Navigate();
        }
    }
}
