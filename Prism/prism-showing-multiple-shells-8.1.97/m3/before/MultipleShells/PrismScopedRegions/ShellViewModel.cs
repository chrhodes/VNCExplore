
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using PrismScopedRegions.Infrastructure;

namespace PrismScopedRegions
{
    public class ShellViewModel : BindableBase
    {
        IRegionManager _regionManager;

        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            OpenShellCommand = new DelegateCommand<string>(OpenShell);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void OpenShell(string viewName)
        {

        }

        void Navigate(string viewName)
        {
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, viewName);
        }
    }
}
