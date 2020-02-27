using System;
using System.Windows.Threading;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace WPFDemo
{
    public abstract class ViewModelBase : BindableBase
    {
        private IAcceleriderUser _acceleriderUser;

        protected ViewModelBase(IUnityContainer container)
        {
            Container = container;
            EventAggregator = container.Resolve<IEventAggregator>();
            Logger = container.Resolve<ILoggerFacade>();
            RegionManager = container.Resolve<IRegionManager>();
        }

        public Dispatcher Dispatcher { get; set; }

        protected IUnityContainer Container { get; }

        protected IEventAggregator EventAggregator { get; }

        protected ILoggerFacade Logger { get; }

        protected IRegionManager RegionManager { get; }

        //public IAcceleriderUser AcceleriderUser => _acceleriderUser ?? (_acceleriderUser = Container.Resolve<IAcceleriderUser>());

        protected virtual void Invoke(Action action) => Dispatcher.Invoke(action);
    }
}
