using NavMenuApp.Commands;
using NavMenuApp.Models;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using System.Windows.Input;

namespace NavMenuApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _enteredUsername;
        public string EnteredUsername
        {
            get
            {
                return _enteredUsername;
            }
            set
            {
                _enteredUsername = value;
                OnPropertyChanged(nameof(EnteredUsername));
            }
        }

        private string _enteredPassword;
        public string EnteredPassword
        {
            get
            {
                return _enteredPassword;
            }
            set
            {
                _enteredPassword = value;
                OnPropertyChanged(nameof(EnteredPassword));
            }
        }

        private string _reEnteredPassword;
        public string ReEnteredPassword
        {
            get
            {
                return _reEnteredPassword;
            }
            set
            {
                _reEnteredPassword = value;
                OnPropertyChanged(nameof(ReEnteredPassword));
            }
        }

        public ICommand RegisterCommand { get; }

        private readonly ErrorMessageStore _errorMessageStore;

        public string ErrorMessage => _errorMessageStore.ErrorMessage;

        public RegisterViewModel(ErrorMessageStore errorMessageStore, INavigationService<LoginViewModel> loginNavigationService)
        {
            _errorMessageStore = errorMessageStore;
            _errorMessageStore.ErrorMessageChanged += OnErrorMessageChanged;

            RegisterCommand = new RegisterCommand(this, errorMessageStore, loginNavigationService);
        }
        private void OnErrorMessageChanged()
        {
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
