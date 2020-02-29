namespace WPFDemo.Infrastructure
{
    public interface ITabItemSelectionChangedAware
    {
        void OnSelected();

        void OnUnselected();
    }
}
