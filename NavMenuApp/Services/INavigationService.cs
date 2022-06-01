using NavMenuApp.ViewModels;

namespace NavMenuApp.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}