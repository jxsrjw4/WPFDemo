using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Plugin.Views
{
    public  class BasePlugin : UserControl
    {
        public string PluginName { get; set; }
        public string PluginVersion { get; set; }
    }
}
