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
    public class UpdateAccountCommand : CommandBase
    {
        private readonly UpdateAccountViewModel _viewModel;
        private readonly INavigationService<HomeViewModel> _navigationService;
        private readonly ErrorMessageStore _errorMessageStore;

        public UpdateAccountCommand(UpdateAccountViewModel viewModel, ErrorMessageStore errorMessageStore, INavigationService<HomeViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
            _errorMessageStore = errorMessageStore;
        }

        public override void Execute(object parameter)
        {
            _errorMessageStore.ErrorMessage = null;

            string resultMessage = new Account()
            {
                Username = _viewModel.EnteredUsername,
            }.UpdateAccount();

            if (resultMessage != null)
            {
                _errorMessageStore.ErrorMessage = resultMessage;
                return;
            }

            _navigationService.Navigate();
        }
    }
}
