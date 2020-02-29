using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Loader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using WCFDemo.Plugins;
using winform = System.Windows.Forms;
namespace WinformWrapper.Views
{
    /// <summary>
    /// WinformPluginView.xaml 的交互逻辑
    /// </summary>
    public partial class WinformPluginView : UserControl
    {
        public WinformPluginView()
        {
            InitializeComponent();
        }

        private winform.UserControl CreateUserControl(string typeName)
        {
            PluginLoaderContext context = new PluginLoaderContext(@"dllpath");
            var dllPath = @"dllpath";
            using (var stream = File.OpenRead(dllPath))
            {
                var assembly = AssemblyLoadContext.Default.LoadFromStream(stream);

                return (winform.UserControl)assembly.CreateInstance(typeName);
                //Type t = assembly.GetType(typeName);

                //return (winform.UserControl)Activator.CreateInstance(t);
            }

            return null;



        }
    }
}
