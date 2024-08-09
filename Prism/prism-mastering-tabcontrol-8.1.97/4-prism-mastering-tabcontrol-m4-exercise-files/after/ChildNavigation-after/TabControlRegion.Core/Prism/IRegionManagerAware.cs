using Prism.Regions;

namespace TabControlRegion.Core.Prism
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
