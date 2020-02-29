using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Integration;
using Unity;
using WPFDemo.Infrastructure;
using WPFDemo.Infrastructure.Models;

namespace WinformWrapper.ViewModels
{
    public class WinformPluginViewModel : ViewModelBase,INavigationAware, IRegionMemberLifetime
    {
        private IRegionManager _regionManager;

        private string _title = "WinformPluginView";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        //默认都用缓存，除非插件更新
        public bool KeepAlive => true;

        public WinformPluginViewModel(IUnityContainer container,  IRegionManager regionManager):base(container)
        {
            _regionManager = regionManager;

            EventAggregator.GetEvent<PluginChangeEvent>().Subscribe(NagivateMenu);
        }

        private void NagivateMenu(BasePluginInfo plugin)
        {
            if (string.IsNullOrEmpty(plugin.PluginName))
            {
                _regionManager.RequestNavigate("ContentRegion", plugin.PluginName);
            }

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
