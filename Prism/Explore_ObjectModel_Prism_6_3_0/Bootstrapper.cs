using Microsoft.Practices.Unity;

using Prism.Unity;
using System.Windows;

namespace Explore_ObjectModel_Prism_6_3_0
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
