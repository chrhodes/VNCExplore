using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
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
