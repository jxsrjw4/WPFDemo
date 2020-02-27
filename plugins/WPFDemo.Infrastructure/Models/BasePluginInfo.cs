using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDemo.Infrastructure.Models
{
    public struct BasePluginInfo
    {
        public string PluginVersion { get; set; }
        public string PluginName { get; set; }
        public string PluginDescription { get; set; }

        public string PluginTypeName { get; set; }
    }
}
