using System;
using System.Collections.Generic;
using System.Text;
namespace WPFDemo.Models
{
    public class MenuItem
    {
        public string MenuItemName { get; set; }
        public string MenuItemIcon { get; set; }
        public int OrderId { get; set; }

        public BasePluginInfo pluginInfo { get; set; }

        public List<MenuItem> subMenuItems { get; set; }
    }
}
