using Prism.Events;
using WPFDemo.Infrastructure.Models;
using WPFDemo.Infrastructure.ServerInteraction;

namespace WPFDemo.Infrastructure
{
    public class PluginChangeEvent : PubSubEvent<BasePluginInfo> { }
    public class MainWindowLoadingEvent : PubSubEvent<bool> { }

    public class SignUpSuccessEvent : PubSubEvent<SignUpArgs> { }
}
