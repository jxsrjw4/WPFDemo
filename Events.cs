using WPFDemo.ServerInteraction;
using Prism.Events;

namespace WPFDemo
{
    internal class MainWindowLoadingEvent : PubSubEvent<bool> { }

    internal class SignUpSuccessEvent : PubSubEvent<SignUpArgs> { }
}
