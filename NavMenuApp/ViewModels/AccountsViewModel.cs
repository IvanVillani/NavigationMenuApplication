using NavMenuApp.Commands;
using NavMenuApp.Services;
using NavMenuApp.Stores;
using NavMenuApp.Models;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

namespace NavMenuApp.ViewModels
{
    public class AccountsViewModel : ViewModelBase
    {
        public List<string> Accounts { get; }
        public AccountsViewModel()
        {
            Accounts = new Account().RetrieveAccounts().Select(acc => acc.Username).ToList();
        }
    }
}
