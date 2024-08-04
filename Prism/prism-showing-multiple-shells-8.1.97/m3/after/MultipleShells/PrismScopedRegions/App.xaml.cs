using System.Windows;
using System.Windows.Controls;

using ModuleA;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

using PrismScopedRegions.Infrastructure;

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
            base.InitializeShell(shell);

            var regionManager = RegionManager.GetRegionManager(shell);
            var region = regionManager.Regions[KnownRegionNames.ContentRegion];
            region.RequestNavigate("ViewA");
            //regionManager.RequestNavigate(KnownRegionNames.ContentRegion, "ViewA");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // NOTE(crhodes)
            // If want the initial shell to have a view loaded,
            // Need to register the view for navigation.
            // This was in ModuleA-RegisterTypes but that is too late
            // for InitializeShell()
            containerRegistry.Register(typeof(object), typeof(ViewA), "ViewA");
            containerRegistry.RegisterSingleton<IShellService, ShellService>();
        }

    }
}
