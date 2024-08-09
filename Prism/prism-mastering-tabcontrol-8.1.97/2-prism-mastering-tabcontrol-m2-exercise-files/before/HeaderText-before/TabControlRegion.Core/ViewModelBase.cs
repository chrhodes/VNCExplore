using Prism.Mvvm;

namespace TabControlRegion.Core
{
    public class ViewModelBase : BindableBase
    {
        string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
