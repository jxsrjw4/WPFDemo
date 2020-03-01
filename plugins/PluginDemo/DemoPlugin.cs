using DemoPlugin.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DemoPlugin
{
    public class DemoPlugin : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DemoPluginView>();
        }
        
    }
}
