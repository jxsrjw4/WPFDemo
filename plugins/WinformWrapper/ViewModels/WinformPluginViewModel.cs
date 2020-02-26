using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Integration;

namespace WinformWrapper.ViewModels
{
    public class BasePluginInfo
    {
        public string PluginVersion { get; set; }
        public string PluginName { get; set; }
        public string PluginDescription { get; set; }

        public string PluginTypeName { get; set; }
    }

    public class WinformPluginViewModel:BindableBase
    {
        public BasePluginInfo plugininfo { get; set; }
        public WinformPluginViewModel()
        {
           
        }
    }
}
