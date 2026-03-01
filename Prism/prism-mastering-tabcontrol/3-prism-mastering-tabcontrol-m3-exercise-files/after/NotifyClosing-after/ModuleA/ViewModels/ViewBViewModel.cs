using Microsoft.Practices.Prism.Regions;
using TabControlRegion.Core;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : ViewModelBase, IConfirmNavigationRequest
    {
        public ViewBViewModel()
        {
            Title = "View B";
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, System.Action<bool> continuationCallback)
        {
            continuationCallback(false);
        }
    }
}
