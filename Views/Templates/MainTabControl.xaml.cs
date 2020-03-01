
using System.Windows;
using System.Windows.Controls;
using WPFDemo.Infrastructure;

namespace WPFDemo.UI.Template
{
    /// <summary>
    /// MainTabControl.xaml 的交互逻辑
    /// </summary>
    public partial class MainTabControl : TabControl
    {
        public MainTabControl()
        {
            InitializeComponent();
        }
        

        private void ExitCommand(MenuBehaviorType type)
        {
            var obj = base.DataContext as MainWindowViewModel;
            if (obj == null) return;
            switch (type)
            {
                case MenuBehaviorType.ExitCurrentPage:
                    obj.ExitPage(MenuBehaviorType.ExitCurrentPage);
                    break;
                case MenuBehaviorType.ExitAllPage:
                    obj.ExitPage(MenuBehaviorType.ExitAllPage);
                    break;
                case MenuBehaviorType.ExitAllExcept:
                    obj.ExitPage(MenuBehaviorType.ExitAllExcept);
                    break;
            }
        }

        private void ExitCurrentPage_Click(object sender, RoutedEventArgs e)
        {
            var plugin = (sender as MenuItem).DataContext as PluginViewModelBase;
            ExitCommand(MenuBehaviorType.ExitCurrentPage);
        }

        private void ExitAllPage_Click(object sender, RoutedEventArgs e)
        {
            var plugin = (sender as MenuItem).DataContext as PluginViewModelBase;
            ExitCommand(MenuBehaviorType.ExitAllPage);
        }

        private void ExitAllExcept_Click(object sender, RoutedEventArgs e)
        {
            var plugin = (sender as MenuItem).DataContext as PluginViewModelBase;
            ExitCommand(MenuBehaviorType.ExitAllExcept);
        }
    }
}
