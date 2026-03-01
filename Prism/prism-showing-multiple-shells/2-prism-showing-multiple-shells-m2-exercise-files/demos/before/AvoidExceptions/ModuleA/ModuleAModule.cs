using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismScopedRegions.Infrastructure;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ModuleAModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ChildRegion", typeof(ViewB));

            IRegion region = _regionManager.Regions[KnownRegionNames.ContentRegion];

            var view1 = _container.Resolve<ViewA>();
            region.Add(view1);
            region.Activate(view1);

            var view2 = _container.Resolve<ViewA>();
            region.Add(view2);
            region.Activate(view2);

            var view3 = _container.Resolve<ViewA>();
            region.Add(view3);
            region.Activate(view3);
        }
    }
}
