using NavMenuApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavMenuApp.Stores
{
    public class AccountStore
    {
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                if (value == null)
                {
                    _currentAccount = new Account()
                    {
                        IsPrivileged = false
                    };
                }else
                {
                    _currentAccount = value;
                }
                CurrentAccountChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount.Username != null;
        public bool IsAccountPrivileged => CurrentAccount.IsPrivileged;

        public event Action CurrentAccountChanged;

        public void Logout()
        {
            CurrentAccount = null;
        }
    }
}
