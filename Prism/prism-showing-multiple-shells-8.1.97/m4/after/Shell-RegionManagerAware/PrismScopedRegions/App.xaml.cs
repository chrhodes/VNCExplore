using System.Windows;

using ModuleA;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

using PrismScopedRegions.Infrastructure;
using PrismScopedRegions.Infrastructure.Prism;
using PrismScopedRegions.Views;

namespace PrismScopedRegions
{
    public partial class App : PrismApplication
    {

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule(typeof(ModuleAModule));

            base.ConfigureModuleCatalog(moduleCatalog);
        }
        
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell(Window shell)
        {
            var regionManager = RegionManager.GetRegionManager(shell);
            RegionManagerAware.SetRegionManagerAware(shell, regionManager);
            
            base.InitializeShell(shell);
            
            // var regionManager = RegionManager.GetRegionManager((Shell));
            // RegionManagerAware.SetRegionManagerAware(Shell, regionManager);            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellService, ShellService>();
        }
    }
}
