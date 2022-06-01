using NavMenuApp.Models;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using NavMenuApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NavMenuApp.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly ErrorMessageStore _errorMessageStore;
        private readonly INavigationService<AccountViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, ErrorMessageStore errorMessageStore, AccountStore accountStore, INavigationService<AccountViewModel> navigationService)
        {
            _viewModel = viewModel;
            _errorMessageStore = errorMessageStore;
            _accountStore = accountStore;
            _navigationService = navigationService;
            _errorMessageStore.ErrorMessage = null;
        }

        public override void Execute(object parameter)
        {
            _errorMessageStore.ErrorMessage = null;

            Account account = new Account()
            {
                Username = _viewModel.Username,
                Password = _viewModel.Password,
            };

            Account fullAccount = account.ValidateAccount();

            _accountStore.CurrentAccount = fullAccount;

            if (fullAccount == null)
            {
                _errorMessageStore.ErrorMessage = "Invalid Login Information!";
                return;
            }

            _navigationService.Navigate();
        }
    }
}
