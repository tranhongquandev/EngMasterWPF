using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private bool _isExpand = true;
        public bool IsExpand
        {
            get => _isExpand;
            set
            {
                _isExpand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MainViewModel()
        {
            SampleList = new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Item 1", SubTitle="Item 1", Notification = 3, SelectedIcon = "Home", UnselectedIcon = "FolderHome" },
                    new SampleItem { Title = "Item 2", SubTitle="Item 1", Notification = 5, SelectedIcon = "Account", UnselectedIcon = "AccountCircleOutline" },
                    new SampleItem { Title = "Item 3", SubTitle="Item 1", Notification = 2, SelectedIcon = "Poll", UnselectedIcon = "Cannabis" },
                };

            ToggleSideBarCommand = new RelayCommand(_canExecute => true, _execute => IsExpand = !IsExpand);
        }


        #region Command

        public ICommand ToggleSideBarCommand { get; private set; }
        #endregion
    }

    public class SampleItem
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Notification { get; set; }
        public string SelectedIcon { get; set; }
        public string UnselectedIcon { get; set; }
    }
}
