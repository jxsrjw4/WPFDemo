using Prism.Regions;
using System.Linq;
using System.Windows;

namespace WPFDemo
{
    public static class ShellSwitcher
    {
        public static Window Show<T>(T window = null) where T : Window, new()
        {
            var shell = Application.Current.MainWindow = window ?? new T();
            shell.Loaded += ProcessController.OnWindowLoaded;
            shell.Show();

            return shell;
        }

        public static void Close<T>() where T : Window
        {
            var shell = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window is T);
            shell?.Close();
        }

        public static void Switch<TClose, TShow>(IRegionManager regionManager)
            where TShow : Window, new()
            where TClose : Window
        {
            var shell = Show<TShow>();
            //多个shell需要共享region manager
            RegionManager.SetRegionManager(shell, regionManager);
            RegionManager.UpdateRegions();
            Close<TClose>();


        }
    }
}
