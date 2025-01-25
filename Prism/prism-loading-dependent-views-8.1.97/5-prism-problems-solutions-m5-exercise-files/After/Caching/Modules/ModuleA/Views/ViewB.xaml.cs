using ModuleA.RibbonTabs;
using Prism.Regions;
using PrismDemo.Core;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewB
    /// </summary>
    [DependentView(typeof(ViewBTab), "RibbonTabRegion")]
    [DependentView(typeof(ViewC), "SubRegion")]
    [RegionMemberLifetime(KeepAlive = false)]
    public partial class ViewB : UserControl, ISupportDataContext
    {
        public ViewB()
        {
            InitializeComponent();
        }
    }
}
