using NavMenuApp.Commands;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NavMenuApp.ViewModels
{
    public class NavigationMenuViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly WindowStore _windowStore;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }
        public ICommand NavigateDeleteAccountCommand { get; }
        public ICommand NavigateUpdateAccountCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand NavigateChatCommand { get; }
        public ICommand NavigateInboxCommand { get; }
        public ICommand NavigateAccountsCommand { get; }
        public ICommand NavigateDebugCommand { get; }

        public bool IsLoggedIn => _accountStore.IsLoggedIn;
        public bool IsLoggedOut => !_accountStore.IsLoggedIn;
        public bool IsAccountPrivileged => _accountStore.IsAccountPrivileged;

        public NavigationMenuViewModel(AccountStore accountStore,
            WindowStore windowStore,
            INavigationService<HomeViewModel> homeNavigationService,
            INavigationService<AccountViewModel> accountNavigationService,
            INavigationService<LoginViewModel> loginNavigationService,
            INavigationService<RegisterViewModel> registerNavigationService,
            INavigationService<DeleteAccountViewModel> deleteAccountNavigationService,
            INavigationService<UpdateAccountViewModel> updateAccountNavigationService,
            INavigationService<ChatViewModel> chatNavigationService,
            INavigationService<InboxViewModel> inboxNavigationService,
            INavigationService<AccountsViewModel> accountsNavigationService,
            INavigationService<DebugViewModel> debugNavigationService)
        {
            _accountStore = accountStore;
            _windowStore = windowStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(registerNavigationService);
            NavigateDeleteAccountCommand = new NavigateCommand<DeleteAccountViewModel>(deleteAccountNavigationService);
            NavigateUpdateAccountCommand = new NavigateCommand<UpdateAccountViewModel>(updateAccountNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore, homeNavigationService);
            NavigateChatCommand = new NavigateCommand<ChatViewModel>(chatNavigationService);
            NavigateInboxCommand = new NavigateCommand<InboxViewModel>(inboxNavigationService);
            NavigateAccountsCommand = new NavigateCommand<AccountsViewModel>(accountsNavigationService);
            NavigateDebugCommand = new NavigateCommand<DebugViewModel>(debugNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        public override void DisposeWindows()
        {
            _windowStore.CloseContent();
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsLoggedOut));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
