using NavMenuApp.Services;
using NavMenuApp.Stores;
using NavMenuApp.ViewModels;
using NavMenuApp.Views;
using System;
using System.Windows;

namespace NavMenuApp
{
    public partial class App : Application
    {
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly WindowStore _windowStore;
        private readonly ErrorMessageStore _errorMessageStore;

        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
            _windowStore = new WindowStore();
            _errorMessageStore = new ErrorMessageStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _accountStore.Logout();
            _errorMessageStore.ErrorMessage = null;

            INavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();

            MenuWindow menu = new MenuWindow()
            {
                DataContext = CreateMenuViewModel()
            };
            _windowStore.Menu = menu;

            MainWindow content = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            _windowStore.Content = content;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                _windowStore.CloseContent();
            }
            finally
            {
                base.OnExit(e);
            }


        }

        private INavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(
                _navigationStore,
                _windowStore,
                () => new HomeViewModel(CreateLoginNavigationService()),
                CreateMenuViewModel);
        }

        private INavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new LayoutNavigationService<LoginViewModel>(
                _navigationStore,
                _windowStore,
                () => new LoginViewModel(_errorMessageStore, _accountStore, CreateAccountNavigationService()),
                CreateMenuViewModel);
        }

        private INavigationService<RegisterViewModel> CreateRegisterNavigationService()
        {
            return new LayoutNavigationService<RegisterViewModel>(
                _navigationStore,
                _windowStore,
                () => new RegisterViewModel(_errorMessageStore, CreateLoginNavigationService()),
                CreateMenuViewModel);
        }

        private INavigationService<DeleteAccountViewModel> CreateDeleteAccountNavigationService()
        {
            return new LayoutNavigationService<DeleteAccountViewModel>(
                _navigationStore,
                _windowStore,
                () => new DeleteAccountViewModel(_errorMessageStore, CreateHomeNavigationService()),
                CreateMenuViewModel);
        }

        private INavigationService<UpdateAccountViewModel> CreateUpdateAccountNavigationService()
        {
            return new LayoutNavigationService<UpdateAccountViewModel>(
                _navigationStore,
                _windowStore,
                () => new UpdateAccountViewModel(_errorMessageStore, CreateHomeNavigationService()),
                CreateMenuViewModel);
        }

        private INavigationService<AccountViewModel> CreateAccountNavigationService()
        {
            return new LayoutNavigationService<AccountViewModel>(
                _navigationStore,
                _windowStore,
                () => new AccountViewModel(_accountStore, CreateHomeNavigationService()),
                CreateMenuViewModel);
        }

        private INavigationService<ChatViewModel> CreateChatNavigationService()
        {
            return new LayoutNavigationService<ChatViewModel>(
                _navigationStore,
                _windowStore,
                () => new ChatViewModel(),
                CreateMenuViewModel);
        }

        private INavigationService<InboxViewModel> CreateInboxNavigationService()
        {
            return new LayoutNavigationService<InboxViewModel>(
                _navigationStore,
                _windowStore,
                () => new InboxViewModel(),
                CreateMenuViewModel);
        }

        private INavigationService<AccountsViewModel> CreateAccountsNavigationService()
        {
            return new LayoutNavigationService<AccountsViewModel>(
                _navigationStore,
                _windowStore,
                () => new AccountsViewModel(),
                CreateMenuViewModel);
        }

        private INavigationService<DebugViewModel> CreateDebugNavigationService()
        {
            return new LayoutNavigationService<DebugViewModel>(
                _navigationStore,
                _windowStore,
                () => new DebugViewModel(),
                CreateMenuViewModel);
        }

        private MenuViewModel CreateMenuViewModel()
        {
            return new MenuViewModel(_accountStore,
                _windowStore,
                CreateHomeNavigationService(),
                CreateAccountNavigationService(),
                CreateLoginNavigationService(),
                CreateRegisterNavigationService(),
                CreateDeleteAccountNavigationService(),
                CreateUpdateAccountNavigationService(),
                CreateChatNavigationService(),
                CreateInboxNavigationService(),
                CreateAccountsNavigationService(),
                CreateDebugNavigationService());
        }
    }
}
