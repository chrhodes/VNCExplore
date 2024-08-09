using System.Windows;

using TabControlRegion.Core;

namespace TabControlRegion.Views
{
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel { get; set; }
    }
}
