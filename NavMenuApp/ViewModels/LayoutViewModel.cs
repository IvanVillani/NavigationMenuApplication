using System;
using System.Collections.Generic;
using System.Text;

namespace NavMenuApp.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public MenuViewModel MenuViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public LayoutViewModel(MenuViewModel navigationMenuViewModel, ViewModelBase contentViewModel)
        {
            MenuViewModel = navigationMenuViewModel;
            ContentViewModel = contentViewModel;
        }

        public override void Dispose()
        {
            MenuViewModel.Dispose();
            ContentViewModel.Dispose();

            base.Dispose();
        }
    }
}
