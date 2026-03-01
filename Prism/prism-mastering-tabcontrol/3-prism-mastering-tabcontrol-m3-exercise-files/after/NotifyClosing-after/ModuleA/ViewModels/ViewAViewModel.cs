using Microsoft.Practices.Prism.Regions;
using TabControlRegion.Core;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        public ViewAViewModel()
        {
            Title = "View A";
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
        }
    }
}
