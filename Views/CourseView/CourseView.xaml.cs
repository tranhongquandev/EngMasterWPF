using EngMasterWPF.SharedUI;
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

namespace EngMasterWPF.Views.CourseView
{
    /// <summary>
    /// Interaction logic for CourseView.xaml
    /// </summary>
    public partial class CourseView : UserControl
    {
        public CourseView()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RootGrid.Children.Add(new ModalCourse());
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void ModalCourse_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
