using System.Windows;

using ModuleA;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using TabControlRegion.Views;

namespace TabControlRegion
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
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
