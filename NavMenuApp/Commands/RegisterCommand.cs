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
    public class RegisterCommand : CommandBase
    {
        private readonly RegisterViewModel _viewModel;
        private readonly INavigationService<LoginViewModel> _navigationService;
        private readonly ErrorMessageStore _errorMessageStore;

        public RegisterCommand(RegisterViewModel viewModel, ErrorMessageStore errorMessageStore, INavigationService<LoginViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            _errorMessageStore = errorMessageStore;
            _errorMessageStore.ErrorMessage = null;
        }

        public override void Execute(object parameter)
        {
            _errorMessageStore.ErrorMessage = null;

            if (_viewModel.EnteredPassword == _viewModel.ReEnteredPassword)
            {
                Account account = new Account()
                {
                    Username = _viewModel.EnteredUsername,
                    Password = _viewModel.EnteredPassword,
                };

                string resultMessage = account.RegisterNewAccount();

                if (resultMessage != null)
                {
                    _errorMessageStore.ErrorMessage = resultMessage;
                    return;
                }

                _navigationService.Navigate();
                return;

            }

            _errorMessageStore.ErrorMessage = "Passwords must be equal!";
        }
    }
}
