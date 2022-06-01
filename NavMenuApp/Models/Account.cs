using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NavMenuApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsPrivileged { get; set; }

        public Account ValidateAccount()
        {
            AccountsContext context = new AccountsContext();
            IEnumerable<Account> dbAccounts = context.Accounts;

            if (!dbAccounts.Any())
            {
                return null;
            }

            foreach (Account account in dbAccounts)
            {
                if (account.Username == Username &&
                    account.Password == Password)
                {
                    return account;
                }
            }

            return null;
        }

        public List<Account> RetrieveAccounts()
        {
            AccountsContext context = new AccountsContext();
            return context.Accounts.ToList();
        }

        public string UpdateAccount()
        {
            AccountsContext context = new AccountsContext();

            Account account = (from acc in context.Accounts
                               where acc.Username == Username
                               select acc).FirstOrDefault();
            if (account == null)
            {
                return "Account not found!";
            }

            account.IsPrivileged = !account.IsPrivileged;
            context.SaveChanges();
            return null;
        }

        public string DeleteAccount()
        {
            AccountsContext context = new AccountsContext();

            Account account = (from acc in context.Accounts
                               where acc.Username == Username
                               select acc).FirstOrDefault();

            if (account == null)
            {
                return "Account not found!";
            }

            context.Accounts.Remove(account);
            context.SaveChanges();
            return null;
        }

        public string RegisterNewAccount()
        {
            AccountsContext context = new AccountsContext();

            if (Username == null)
            {
                return "Username not entered!";
            }else if (Password == null)
            {
                return "Password not entered!";
            }else if (IsAccountUsernameTaken())
            {
                return "Username already taken!";
            }

            IsPrivileged = false;
            context.Accounts.Add(this);
            context.SaveChanges();

            return null;
        }

        private bool IsAccountUsernameTaken()
        {
            AccountsContext context = new AccountsContext();
            IEnumerable<Account> dbAccounts = context.Accounts;

            if (!dbAccounts.Any())
            {
                return false;
            }

            foreach (Account account in dbAccounts)
            {
                if (account.Username == Username)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
