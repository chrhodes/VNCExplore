using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using PrismScopedRegions.Infrastructure;

namespace PrismScopedRegions.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        IRegionManager _regionManager;
        private readonly IShellService _service;

        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public ShellViewModel(IRegionManager regionManager, IShellService service)
        {
            _regionManager = regionManager;
            _service = service;

            OpenShellCommand = new DelegateCommand<string>(OpenShell);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void OpenShell(string viewName)
        {
            _service.ShowShell(viewName);
        }

        void Navigate(string viewName)
        {
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, viewName);
        }
    }
}
