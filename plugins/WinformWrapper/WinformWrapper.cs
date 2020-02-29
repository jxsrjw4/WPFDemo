using Plugin.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using WinformWrapper.Views;

namespace WCFDemo.WinformWrapper
{
	public class WinformWrapper : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			//regionManager.RegisterViewWithRegion("WinfromWrapperRegion", typeof(WinformPluginView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<WinformPluginView>("WinformPlugin");
			containerRegistry.RegisterForNavigation<DemoView>("DemoView");
		}

	}
}
