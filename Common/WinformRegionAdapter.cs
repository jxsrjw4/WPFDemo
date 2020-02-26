using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms.Integration;

namespace WPFDemo.Common
{
    public class WinformRegionAdapter: RegionAdapterBase<WindowsFormsHost>
    {
        public WinformRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, WindowsFormsHost regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (System.Windows.Forms.Control element in e.NewItems)
                    {
                        regionTarget.Child.Controls.Add(element);
                    }
                }

                //handle remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
