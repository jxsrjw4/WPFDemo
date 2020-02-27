using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WPFDemo.Common;
using WPFDemo.Infrastructure;
using WPFDemo.Infrastructure.Models;
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
        private IEventAggregator _ea;

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<int> MenuItemChangedCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _ea = ea;


            NavigateCommand = new DelegateCommand<string>(NagivateMenu);
            //MenuItemChangedCommand = new DelegateCommand<int>(ListViewMenu_SelectionChanged);
            _menuitems.Add(new MenuItem { MenuItemName="主页", MenuItemIcon="Home", pluginInfo = new BasePluginInfo { PluginTypeName="PluginDemoView"} });
            _menuitems.Add(new MenuItem { MenuItemName = "用户", MenuItemIcon = "User", pluginInfo = new BasePluginInfo { PluginTypeName = "PluginDemoView" } });

        }

        private void NagivateMenu(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                _regionManager.RequestNavigate("ContentRegion", path);
            }
        }


        private void OnPluginChanged(BasePluginInfo plugin)
        {
            _ea.GetEvent<PluginChangeEvent>().Publish(plugin);
        }
    }
}
