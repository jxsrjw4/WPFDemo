using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.ViewModels
{
    //Plugin.ViewModels.DemoPluginViewModel
    public class  DemoPluginViewModel: BindableBase
    {
        private string _title = "Prism Unity Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public DemoPluginViewModel()
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




    }
}
