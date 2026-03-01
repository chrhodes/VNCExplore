using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;

namespace TabControlRegion.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> NavigateCommand {get; set;}

        public MainWindowViewModel()
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            
        }
    }
}
