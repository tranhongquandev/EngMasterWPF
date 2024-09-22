using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Property

        private ObservableCollection<SampleItem>? _sampleList;
        public ObservableCollection<SampleItem> SampleList
        {
            get => _sampleList!;
            set
            {
                _sampleList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MainViewModel()
        {
            SampleList = new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Item 1", Notification = 3, SelectedIcon = "Home", UnselectedIcon = "FolderHome" },
                    new SampleItem { Title = "Item 2", Notification = 5, SelectedIcon = "Account", UnselectedIcon = "AccountCircleOutline" },
                    new SampleItem { Title = "Item 3", Notification = 2, SelectedIcon = "Poll", UnselectedIcon = "Cannabis" },
                };
        }
    }

    public class SampleItem
    {
        public string Title { get; set; }
        public int Notification { get; set; }
        public string SelectedIcon { get; set; }
        public string UnselectedIcon { get; set; }
    }
}
