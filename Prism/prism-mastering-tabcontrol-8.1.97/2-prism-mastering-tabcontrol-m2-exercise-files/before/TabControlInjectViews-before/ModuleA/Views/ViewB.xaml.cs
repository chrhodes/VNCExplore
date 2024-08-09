using System.Windows.Controls;

using TabControlRegion.Core;

namespace ModuleA.Views
{
    public partial class ViewB : UserControl, IView
    {
        public ViewB()
        {
            InitializeComponent();
        }
        
        public IViewModel ViewModel { get; set; }
    }
}
