using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using Refit;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using WPFDemo.Common;
using WPFDemo.Infrastructure;
using WPFDemo.ServerInteraction;
using WinForm = System.Windows.Forms;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ProcessController.CheckSingleton();
            System.Windows.Forms.Application.EnableVisualStyles();
            WindowsFormsHost.EnableWindowsFormsInterop();
            base.OnStartup(e);

        }
        protected override Window CreateShell()
        {
            return new LoginView();
            //return Container.Resolve<MainWindow>();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ConfigureApplicationEventHandlers();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoggerFacade, Logger>();
            containerRegistry.RegisterInstance<ISnackbarMessageQueue>(new SnackbarMessageQueue(TimeSpan.FromSeconds(2)));
            containerRegistry.RegisterInstance(new ConfigureFile().Load());
            containerRegistry.RegisterInstance(RestService.For<INonAuthenticationApi>(AcceleriderUrls.ApiBaseAddress));
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //模块权限控制
            //return ModuleCatalog.CreateFromXaml(new Uri("ModuleCatalog.xaml", UriKind.Relative));
            //通过目录加载插件
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //var moduleAType = typeof(DemoPlugin);
            //moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleAType.Name,
            //    ModuleType = moduleAType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});

            //模块权限控制
            //ModuleCatalog.CreateFromXaml("");
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(WindowsFormsHost), Container.Resolve<WinformRegionAdapter>());
        }

        protected override void ConfigureViewModelLocator()
        {
            //ViewModelLocationProvider.SetDefaultViewModelFactory(new ViewModelResolver(() => Container).UseDefaultConfigure().ResolveViewModelForView);

            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                viewName = viewName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
                var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
                return Type.GetType(viewModelName);
            });
        }

        private void ConfigureApplicationEventHandlers()
        {
            var handler = Container.Resolve<ExceptionHandler>();
            AppDomain.CurrentDomain.UnhandledException += handler.UnhandledExceptionHandler;
            Current.DispatcherUnhandledException += handler.DispatcherUnhandledExceptionHandler;
        }
    }
}
