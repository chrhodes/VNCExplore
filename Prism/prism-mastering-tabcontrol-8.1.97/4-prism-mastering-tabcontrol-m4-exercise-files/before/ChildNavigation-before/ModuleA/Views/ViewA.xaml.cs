using System.Windows.Controls;

using TabControlRegion.Core;
using TabControlRegion.Core.Prism;

namespace ModuleA.Views
{
    public partial class ViewA : UserControl, IView, ICreateRegionManagerScope
    {
        public ViewA()
        {
            InitializeComponent();
        }

        public bool CreateRegionManagerScope
        {
            get { return true; }
        }

        public IViewModel ViewModel { get; set; }
    }
}
