﻿using NavMenuApp.Commands;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using System.Windows.Input;

namespace NavMenuApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(INavigationService<LoginViewModel> loginNavigationService)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
