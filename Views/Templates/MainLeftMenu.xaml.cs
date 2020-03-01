
using System.Windows;
using System.Windows.Controls;

namespace WPFDemo.UI.Template
{
    /// <summary>
    /// MainLeftMenu.xaml 的交互逻辑
    /// </summary>
    public partial class MainLeftMenu : UserControl
    {
        public MainLeftMenu()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
    }
}
