
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using PrismScopedRegions.Infrastructure;

namespace ModuleA
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand NavigateCommand { get; set; }

        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        void Navigate()
        {
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, "ViewB");
        }
    }
}
