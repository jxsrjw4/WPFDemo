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
    public class WinformPluginViewModel : PluginViewModelBase,INavigationAware
    {
        private string _title = "WinformPluginView";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public WinformPluginViewModel(IUnityContainer container):base(container)
        {
            EventAggregator.GetEvent<PluginChangeEvent>().Subscribe(NagivateMenu);
        }

        private void NagivateMenu(BasePluginInfo plugin)
        {
            if (string.IsNullOrEmpty(plugin.PluginName))
            {
                RegionManager.RequestNavigate("ContentRegion", plugin.PluginName);
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
