using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFDemo.Common;
using WPFDemo.Models;

namespace WPFDemo
{
    public class MainWindowViewModel: BindableBase
    {
        //菜单
        private ObservableCollection<MenuItem> _menuitems = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuitems; }
            set { SetProperty(ref _menuitems, value); }
        }

        private IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<int> MenuItemChangedCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(NagivateMenu);
            //MenuItemChangedCommand = new DelegateCommand<int>(ListViewMenu_SelectionChanged);
            _menuitems.Add(new MenuItem { MenuItemName="主页", MenuItemIcon="Home", pluginInfo = new BasePluginInfo { PluginTypeName="PluginDemoView"} });
            _menuitems.Add(new MenuItem { MenuItemName = "用户", MenuItemIcon = "User", pluginInfo = new BasePluginInfo { PluginTypeName = "PluginDemoView" } });

        }


        private void NagivateMenu(string navigatePath)
        {
            if (navigatePath != null)
            {
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }
    }
}
