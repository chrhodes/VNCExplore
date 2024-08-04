using System.Windows.Controls;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using PrismScopedRegions.Infrastructure;

namespace PrismScopedRegions
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
            // NOTE(crhodes)
            // This opens a new shell
            //_service.ShowShell();

            // NOTE(crhodes)
            // This opens a new shell and navigates to viewName
            _service.ShowShell(viewName);
        }

        void Navigate(string viewName)
        {
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, viewName);
        }
    }
}
