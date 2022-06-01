using NavMenuApp.Commands;
using NavMenuApp.Models;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using System.Windows.Input;

namespace NavMenuApp.ViewModels
{
    public class DeleteAccountViewModel : ViewModelBase
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

        public ICommand DeleteAccountCommand { get; }

        private readonly ErrorMessageStore _errorMessageStore;

        public string ErrorMessage => _errorMessageStore.ErrorMessage;

        public DeleteAccountViewModel(ErrorMessageStore errorMessageStore, INavigationService<HomeViewModel> homeNavigationService)
        {
            _errorMessageStore = errorMessageStore;
            _errorMessageStore.ErrorMessageChanged += OnErrorMessageChanged;

            DeleteAccountCommand = new DeleteAccountCommand(this, errorMessageStore, homeNavigationService);
        }

        private void OnErrorMessageChanged()
        {
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
