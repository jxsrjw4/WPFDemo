using MaterialDesignThemes.Wpf;

namespace WPFDemo.Infrastructure
{
    public interface INotificable
    {
        ISnackbarMessageQueue GlobalMessageQueue { get; set; }
    }
}
