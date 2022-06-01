using NavMenuApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace NavMenuApp.Stores
{
    public class WindowStore
    {
        private Window _menu;
        public Window Menu
        {
            get => _menu;
            set
            {
                _menu?.Close();
                _menu = value;
                _menu.Height = SystemParameters.WorkArea.Height;
                _menu.Left = 0;
                _menu.Top = 0;
                _menu?.Show();
            }
        }

        private Window _content;
        public Window Content
        {
            get => _content;
            set
            {
                _content?.Close();
                _content = value;
            }
        }

        public void UpdateMenuDataContext(ViewModelBase dataContext)
        {
            if (_menu != null)
            {
                _menu.DataContext = dataContext;
            }
        }

        public void ShowContent()
        {
            if (_menu != null)
            {
                SetContentWindowPosition();
                _content?.Show();
            }
        }

        public void CreateContent(NavigationStore navigationStore)
        {
            _content?.Close();
            _content = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
        }

        public void CloseContent()
        {
            _content?.Close();
        }

        public void SetContentWindowPosition()
        {
            if (_content != null && _menu != null)
            {
                _content.Left = _menu.Left + _menu.ActualWidth;
                _content.Top = _menu.Top;
            }
        }
    }
}
