using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Microsoft.Xaml.Behaviors;

using Prism.Regions;

namespace TabControlRegion
{
    public class CloseTabAction : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            var args = parameter as RoutedEventArgs;
            if (args == null)
                return;

            var tabItem = FindParent<TabItem>(args.OriginalSource as DependencyObject);
            if (tabItem == null)
                return;

            var tabControl = FindParent<TabControl>(tabItem);
            if (tabControl == null)
                return;

            IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
            if (region == null)
                return;

            RemoveItemFromRegion(tabItem.Content, region);
        }

        void RemoveItemFromRegion(object item, IRegion region)
        {
            var navigationContext = new NavigationContext(region.NavigationService, null);
            if (CanRemove(item, navigationContext))
            {
                region.Remove(item);
            }
        }

        bool CanRemove(object item, NavigationContext navigationContext)
        {
            bool canRemove = true;

            var confirmRequestItem = item as IConfirmNavigationRequest;
            if (confirmRequestItem != null)
            {
                confirmRequestItem.ConfirmNavigationRequest(navigationContext, result =>
                {
                    canRemove = result;
                });
            }

            var frameworkElement = item as FrameworkElement;
            if (frameworkElement != null && canRemove)
            {
                IConfirmNavigationRequest confirmRequestDataContext = frameworkElement.DataContext as IConfirmNavigationRequest;
                if (confirmRequestDataContext != null)
                {
                    confirmRequestDataContext.ConfirmNavigationRequest(navigationContext, result =>
                    {
                        canRemove = result;
                    });
                }
            }

            return canRemove;
        }

        static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            var parent = parentObject as T;
            if (parent != null)
                return parent;

            return FindParent<T>(parentObject);
        }
    }
}
