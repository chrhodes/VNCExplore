﻿
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using PrismScopedRegions.Infrastructure;
using PrismScopedRegions.Infrastructure.Prism;

namespace ModuleA
{
    public class ViewAViewModel : BindableBase, IRegionManagerAware
    {
        public DelegateCommand NavigateCommand { get; set; }

        // NOTE(crhodes)
        // This does not get the global RegionManager passed in the Constructor

        public ViewAViewModel()
        {
            NavigateCommand = new DelegateCommand(Navigate);
        }

        void Navigate()
        {
            RegionManager.RequestNavigate(KnownRegionNames.ContentRegion, "ViewB");
        }

        public IRegionManager RegionManager 
        { 
            get; 
            set; 
        }

    }
}
