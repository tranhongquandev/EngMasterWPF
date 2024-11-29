using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EngMasterWPF.Views.StudentView
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        public StudentView()
        {
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
