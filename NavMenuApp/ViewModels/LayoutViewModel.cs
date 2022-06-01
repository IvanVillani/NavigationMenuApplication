using System;
using System.Collections.Generic;
using System.Text;

namespace NavMenuApp.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public NavigationMenuViewModel NavigationMenuViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public LayoutViewModel(NavigationMenuViewModel navigationMenuViewModel, ViewModelBase contentViewModel)
        {
            NavigationMenuViewModel = navigationMenuViewModel;
            ContentViewModel = contentViewModel;
        }

        public override void Dispose()
        {
            NavigationMenuViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
