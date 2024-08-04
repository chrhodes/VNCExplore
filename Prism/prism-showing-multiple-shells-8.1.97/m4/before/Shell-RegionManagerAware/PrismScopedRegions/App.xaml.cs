using System.Windows;

using ModuleA;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using PrismScopedRegions.Infrastructure;
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
            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellService, ShellService>();
        }
    }
}
