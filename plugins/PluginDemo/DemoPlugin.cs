﻿using Plugin.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace plugin_demo
{
    public class DemoPlugin : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(DemoPluginView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
        
    }
}
