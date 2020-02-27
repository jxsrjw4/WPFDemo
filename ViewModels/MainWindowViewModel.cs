using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Unity;
using WPFDemo.Common;
using WPFDemo.Infrastructure;
using WPFDemo.Infrastructure.Models;
using WPFDemo.Models;

namespace WPFDemo
{
    public class MainWindowViewModel: ViewModelBase
    {
        //菜单
        private ObservableCollection<MenuItem> _menuitems = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuitems; }
            set { SetProperty(ref _menuitems, value); }
        }

        public DelegateCommand<MenuItem> NavigateCommand { get; private set; }
        public DelegateCommand<MenuItem> MenuItemChangedCommand { get; private set; }

        public MainWindowViewModel(IUnityContainer container,IRegionManager regionManager):base(container)
        {
            NavigateCommand = new DelegateCommand<MenuItem>(NagivateMenu);
            MenuItemChangedCommand = new DelegateCommand<MenuItem>(OnPluginChanged);
            _menuitems.Add(new MenuItem { MenuItemName="主页", MenuItemIcon="Home", pluginInfo = new BasePluginInfo { PluginTypeName="PluginDemoView",PluginName= "DemoPlugin" } });
            _menuitems.Add(new MenuItem { MenuItemName = "用户", MenuItemIcon = "User", pluginInfo = new BasePluginInfo { PluginTypeName = "WinformPluginWrapper", PluginName= "WinformPluginWrapper" } });

            }


        private void NagivateMenu(MenuItem menu)
        {
            var parameters = new NavigationParameters();
            parameters.Add("pluginInfo", menu.pluginInfo);

            if (menu != null)
                RegionManager.RequestNavigate("ContentRegion", menu.pluginInfo.PluginName);
        }


        private void OnPluginChanged(MenuItem menu)
        {
            EventAggregator.GetEvent<PluginChangeEvent>().Publish(menu.pluginInfo);
        }
    }
}
