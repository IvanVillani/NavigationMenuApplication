using System;
using System.Collections.Generic;
using System.Data.Entity;
using NavMenuApp.Models;
using System.Text;

namespace NavMenuApp.Models
{
    internal class AccountsContext : DbContext
    {
        public AccountsContext() : base(Properties.Settings.Default.DbConnect)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
