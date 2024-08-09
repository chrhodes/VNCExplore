using System.Windows.Controls;

using TabControlRegion.Core;

namespace ModuleA.Views
{
    public partial class ViewA : UserControl, IView
    {
        public ViewA()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel { get; set; }
    }
}
