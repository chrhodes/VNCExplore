using ModuleA.Views;

using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        //private readonly IUnityContainer _container;

        //public ModuleAModule(IUnityContainer container)
        //{
        //    _container = container;
        //}

        //public void Initialize()
        //{
        //    _container.RegisterType<object, ViewA>("ViewA");
        //    _container.RegisterType<object, ViewB>("ViewB");
        //}

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
