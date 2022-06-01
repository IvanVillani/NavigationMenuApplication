using System;
using System.Collections.Generic;
using System.Text;

namespace NavMenuApp.Stores
{
    public class ErrorMessageStore
    {
        private string _errorMessage;
        public string ErrorMessage 
        {
            get
            {
                if (_errorMessage == null)
                {
                    return "";
                }
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                ErrorMessageChanged?.Invoke();
            } 
        }

        public event Action ErrorMessageChanged;
    }
}
