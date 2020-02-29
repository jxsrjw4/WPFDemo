using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.ViewModels
{
    public class DemoViewModel:BindableBase
    {
        private string _title = "DemoView";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DemoViewModel()
        {

        }
    }
}
