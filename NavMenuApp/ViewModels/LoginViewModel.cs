using NavMenuApp.Commands;
using NavMenuApp.Models;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using System.Windows.Input;

namespace NavMenuApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        private readonly ErrorMessageStore _errorMessageStore;

        public string ErrorMessage => _errorMessageStore.ErrorMessage;


        public LoginViewModel(ErrorMessageStore errorMessageStore, AccountStore accountStore, INavigationService<AccountViewModel> accountNavigationService)
        {
            _errorMessageStore = errorMessageStore;
            _errorMessageStore.ErrorMessageChanged += OnErrorMessageChanged;

            LoginCommand = new LoginCommand(this, errorMessageStore, accountStore, accountNavigationService);
        }

        private void OnErrorMessageChanged()
        {
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
