using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WPFDemo.ViewModels
{
    public class Menu
    { 
        public string MenuName { get; set; }
        public string MenuIcon { get; set; }
        public int OrderId { get; set; }
    }
    public class MainWindowViewModel: BindableBase
    {
        //菜单
        private ObservableCollection<Menu> _menuitems = new ObservableCollection<Menu>();
        public ObservableCollection<Menu> MenuItems
        {
            get { return _menuitems; }
            set { SetProperty(ref _menuitems, value); }
        }

        public MainWindowViewModel()
        {
            _menuitems.Add(new  Menu { MenuName = "主页", MenuIcon = "Home", OrderId = 0 });
            _menuitems.Add(new Menu { MenuName = "用户", MenuIcon = "User", OrderId = 1 });

        }
    }
}
