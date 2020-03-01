using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Unity;
using WPFDemo.Infrastructure;
using WPFDemo.Infrastructure.Models;

namespace WPFDemo
{
    public class MainWindowViewModel: PluginViewModelBase
    {
        ///// <summary>
        /// 已加载模块<含分组>
        /// </summary>
        private ObservableCollection<ModuleGroup> _menuitems = new ObservableCollection<ModuleGroup>();
        public ObservableCollection<ModuleGroup> ModuleGroup
        {
            get { return _menuitems; }
            set { SetProperty(ref _menuitems, value); }
        }

        public BasePluginInfo CurrentPluinInfo { get; set; }
        public DelegateCommand<BasePluginInfo> NavigateCommand { get; private set; }
        public DelegateCommand<MenuItem> MenuItemChangedCommand { get; private set; }

        public MainWindowViewModel(IUnityContainer container) :base(container)
        {
            NavigateCommand = new DelegateCommand<BasePluginInfo>(NagivateMenu);
            //MenuItemChangedCommand = new DelegateCommand<MenuItem>(OnPluginChanged);
            _menuitems.Add(new ModuleGroup 
            { 
                ModuleType=ModuleType.BasicData, 
                GroupIcon="Home",
                GroupName = "首页",
                Modules = new List<BasePluginInfo>() { new BasePluginInfo{ PluginTypeName = "PluginDemoView", PluginName = "DemoPluginView" },new BasePluginInfo { PluginTypeName = "WinformPluginWrapper", PluginName = "DemoView" } } });
            _menuitems.Add(new ModuleGroup
            {
                ModuleType = ModuleType.SystemSettings,
                GroupIcon = "User",
                GroupName = "用户",
                Modules = new List<BasePluginInfo>() { new BasePluginInfo { PluginTypeName = "PluginDemoView", PluginName = "DemoPluginView" }, new BasePluginInfo { PluginTypeName = "WinformPluginWrapper", PluginName = "DemoView" } }
            });

            _menuitems.Add(new ModuleGroup
            {
                ModuleType = ModuleType.SystemSettings,
                GroupIcon = "Setting",
                GroupName="设置",
                Modules = new List<BasePluginInfo>() { new BasePluginInfo { PluginTypeName = "PluginDemoView", PluginName = "DemoPluginView" }, new BasePluginInfo { PluginTypeName = "WinformPluginWrapper", PluginName = "DemoView" } }
            });


        }


        private void NagivateMenu(BasePluginInfo pluginInfo)
        {
            //_moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = "WCFDemo.Plugins.DemoPlugin",
            //    ModuleType = "PluginDemo.dll",
            //    InitializationMode = InitializationMode.OnDemand
            //});
            //var plugin = Container.Resolve<IPlugin>("DemoPlugin");
            //IRegion region = _regionManager.Regions["WinfromWrapperRegion"];
            //region.Add(plugin);

            var parameters = new NavigationParameters();
            parameters.Add("pluginInfo", pluginInfo);

            
            {
                CurrentPluinInfo = pluginInfo;
                RegionManager.RequestNavigate("WinfromWrapperRegion", pluginInfo.PluginName, NavigationCompleted);
                EventAggregator.GetEvent<PluginChangeEvent>().Publish(pluginInfo);
            }
        }

        /// <summary>
        /// 插件退出
        /// </summary>
        /// <param name="behaviorType"></param>
        /// <param name="pluginName"></param>
        public void ExitPage(MenuBehaviorType behaviorType)
        {
            IRegion region = RegionManager.Regions["WinfromWrapperRegion"];

            var ActiveViews = region.ActiveViews;
            switch (behaviorType)
            {
                case MenuBehaviorType.ExitCurrentPage:
                    ActiveViews.ForEach(item =>
                    {
                        region.Remove(item);
                    });
                    break;
                case MenuBehaviorType.ExitAllPage:
                    region.RemoveAll();
                    break;
                case MenuBehaviorType.ExitAllExcept:
                    region.Views.ForEach(item =>
                    {
                        if (!ActiveViews.Contains(item))
                        {
                            region.Remove(item);
                        }
                    });
                    break;
            }
        }

        private void NavigationCompleted(NavigationResult result)
        {
            
        }

        public void OnLoaded()
        {
            //    var region = _regionManager.Regions["ContentRegion"];
            //    region.ActiveViews.CollectionChanged += OnActiveViewsChanged;

            //GlobalMessageQueue.Enqueue(UiStrings.Message_Welcome);

            RegionManager.RequestNavigate("WinfromWrapperRegion", "DefaultDashboard", NavigationCompleted);
        }

        public void OnUnloaded()
        {
        }

        private void OnActiveViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;

        }
    }

}
