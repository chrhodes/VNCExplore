using Prism.Regions;

using PrismScopedRegions.Infrastructure;

using Unity;

namespace PrismScopedRegions
{
    public class ShellService : IShellService
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ShellService(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void ShowShell()
        {
            var shell = _container.Resolve<Shell>();

            var scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);

            shell.Show();
        }

        public void ShowShell(string uri)
        {
            var shell = _container.Resolve<Shell>();

            var scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);

            scopedRegion.RequestNavigate(KnownRegionNames.ContentRegion, uri);

            shell.Show();
        }
    }
}
