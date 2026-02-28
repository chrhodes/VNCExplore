using System;
using System.Threading;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismScopedRegions.Infrastructure;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ChildRegion", typeof(ViewB));

            IRegion region = _regionManager.Regions[KnownRegionNames.ContentRegion];

            ////Start with one ViewA that has a content Region (ChildRegion) for ViewB
            //var view1 = containerProvider.Resolve<ViewA>();
            //region.Add(view1);
            //region.Activate(view1);

            //// Then add more ViewA's that also have content Regions for ViewB.
            //// This causes an exception because the region manager
            //// doesn't know how to handle multiple regions with the same name.

            //var view2 = containerProvider.Resolve<ViewA>();
            //region.Add(view2);
            //region.Activate(view2);

            //var view3 = containerProvider.Resolve<ViewA>();
            //region.Add(view3);
            //region.Activate(view3);

            // NOTE(crhodes)
            // Solution
            // Create a region manager scope for each view
            // that has a region with the same name.
            // This allows each view to have its own instance of the region manager
            // and avoids the exception.
            // Create region manager scope and add view to region
            var view1 = containerProvider.Resolve<ViewA>();
            IRegionManager scopedRegion1 = region.Add(view1, viewName: null, createRegionManagerScope: true);
            //region.Activate(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            IRegionManager scopedRegion2 = region.Add(view2, null, true);
            //region.Activate(view2);

            // NOTE(crhodes)
            // Alternatively, you could also create a new scopedRegion
            // and attach view to it using static method on RegionManager.

            var view3 = containerProvider.Resolve<ViewA>();
            IRegionManager scopedRegion3 = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(view3, scopedRegion3);
            region.Activate(view3);
            //region.Add(view3);


            //Thread.Sleep(5000);
            //// Cannot Deactivate a view in an AllActiveRegion (ItemsControl)
            //// but can remove views from it.
            ////region.Deactivate(view1);
            //region.Remove(view1);
            //Thread.Sleep(1000);
            //region.Remove(view2);
            //Thread.Sleep(1000);
            //region.Remove(view3);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
