using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRegionManager _regionManager;
        public MainWindow(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs  e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            string navigatePath = "";
            switch (index)
            {
                case 0:
                    navigatePath = "WinformPluginWrapper";
                    break;
                default:
                    navigatePath = "DemoPlugin";
                    break;
            }

            if (navigatePath != null)
            {
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
            }

        }

    }
}
