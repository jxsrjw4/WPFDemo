using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Integration;
using WPFDemo.Infrastructure;
using WPFDemo.Infrastructure.Models;

namespace WinformWrapper.ViewModels
{
    public class WinformPluginViewModel:BindableBase
    {
        private IEventAggregator _ea;
        private IRegionManager _regionManager;

        public WinformPluginViewModel(IEventAggregator ea, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _ea = ea;

            _ea.GetEvent<PluginChangeEvent>().Subscribe(NagivateMenu);
        }

        private void NagivateMenu(BasePluginInfo plugin)
        {
            if (string.IsNullOrEmpty(plugin.PluginName))
            {
                _regionManager.RequestNavigate("ContentRegion", plugin.PluginName);
            }

        }
    }
}
