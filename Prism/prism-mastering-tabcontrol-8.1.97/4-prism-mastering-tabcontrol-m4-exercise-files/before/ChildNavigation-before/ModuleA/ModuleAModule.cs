using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using ModuleA.Views;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<object, ViewA>("ViewA");
            containerRegistry.Register<object, ViewB>("ViewB");
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }
    }
}
