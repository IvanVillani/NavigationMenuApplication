using NavMenuApp.Stores;
using NavMenuApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavMenuApp.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly WindowStore _windowStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<MenuViewModel> _createMenuViewModel;

        public LayoutNavigationService(NavigationStore navigationStore, 
            WindowStore windowStore,
            Func<TViewModel> createViewModel,
            Func<MenuViewModel> createMenuViewModel)
        {
            _navigationStore = navigationStore;
            _windowStore = windowStore;
            _createViewModel = createViewModel;
            _createMenuViewModel = createMenuViewModel;
        }

        public void Navigate()
        {
            MenuViewModel navigationMenuViewModel = _createMenuViewModel();

            _windowStore.UpdateMenuDataContext(navigationMenuViewModel);

            _windowStore.CreateContent(_navigationStore);
            _windowStore.ShowContent();

            _navigationStore.CurrentViewModel = new LayoutViewModel(navigationMenuViewModel, _createViewModel());
        }
    }
}
