using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using PrismRoles.Views;
using System.Security.Principal;
using System.Threading;
using Prism.Unity;

namespace PrismRoles
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            //TODO: get your login/role information from your source and set the IIdentity/IPrincipal
            var ident = WindowsIdentity.GetCurrent();
            var p = new GenericPrincipal(ident, new string[] { "User", "Admin" });
            Thread.CurrentPrincipal = p;

            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IModuleInitializer, PrismRoles.Core.Prism.RoleBasedModuleInitializer>(new ContainerControlledLifetimeManager());
        }
    }
}
