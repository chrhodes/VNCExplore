using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(object), typeof(ViewA), "ViewA");
            containerRegistry.Register(typeof(object), typeof(ViewB), "ViewB");
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }
    }
}
