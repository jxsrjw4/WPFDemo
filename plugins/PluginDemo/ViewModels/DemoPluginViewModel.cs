using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using WPFDemo.Infrastructure;

namespace DemoPlugin.ViewModels
{
    //Plugin.ViewModels.DemoPluginViewModel
    public class  DemoPluginViewModel: PluginViewModelBase,INavigationAware
    {
        private string _title = "Prism Unity Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public DemoPluginViewModel(IUnityContainer container):base(container)
        {
            ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);

        }

        private void Execute()
        {
            Title = $"Updated: {DateTime.Now}";
        }

        private void ExecuteGeneric(string parameter)
        {
            Title = parameter;
        }

        private bool CanExecute()
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            ///用于传参
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
