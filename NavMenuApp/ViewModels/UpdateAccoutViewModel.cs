using NavMenuApp.Commands;
using NavMenuApp.Models;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using System.Windows.Input;

namespace NavMenuApp.ViewModels
{
    public class UpdateAccountViewModel : ViewModelBase
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

        public ICommand UpdateAccountCommand { get; }

        private readonly ErrorMessageStore _errorMessageStore;

        public string ErrorMessage => _errorMessageStore.ErrorMessage;

        public UpdateAccountViewModel(ErrorMessageStore errorMessageStore, INavigationService<HomeViewModel> homeNavigationService)
        {
            _errorMessageStore = errorMessageStore;
            _errorMessageStore.ErrorMessageChanged += OnErrorMessageChanged;

            UpdateAccountCommand = new UpdateAccountCommand(this, errorMessageStore, homeNavigationService);
        }

        private void OnErrorMessageChanged()
        {
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
