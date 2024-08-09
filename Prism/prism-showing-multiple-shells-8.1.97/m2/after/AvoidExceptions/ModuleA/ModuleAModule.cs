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

            var view1 = containerProvider.Resolve<ViewA>();
            //region.Add(view1);
            // NOTE(crhodes)
            // Create region manager scope and add view to region
            IRegionManager r1 = region.Add(view1, null, true);
            region.Activate(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            IRegionManager r2 = region.Add(view2, null, true);
            region.Activate(view2);

            var view3 = containerProvider.Resolve<ViewA>();
            IRegionManager r3 = region.Add(view3, null, true);
            region.Activate(view3);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
