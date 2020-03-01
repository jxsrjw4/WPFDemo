using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using WPFDemo.Infrastructure.Models;

namespace WPFDemo.Infrastructure
{
    public class PluginViewModelBase : ViewModelBase, IViewLoadedAndUnloadedAware, IRegionMemberLifetime
    {
        private bool _keepAlive = true;

        public BasePluginInfo pluginfo { get; set; }

        public bool KeepAlive 
        {
            get 
            {
                return _keepAlive;
            }
        }

        public PluginViewModelBase(IUnityContainer container) : base(container)
        { 
        
        }

        public void OnLoaded()
        {
            
        }

        public void OnUnloaded()
        {
            
        }
    }
}
