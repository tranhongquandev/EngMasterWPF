using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ModalAddStudent.xaml
    /// </summary>
    public partial class ModalAddStudent : UserControl
    {
        public ModalAddStudent()
        {
            InitializeComponent();
        }

        private void PhoneNumber_Validation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]"); 
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Email_Validation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            string currentText = ((TextBox)sender).Text + e.Text;
            if (!regex.IsMatch(currentText))
            {
                e.Handled = true;  
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is DateTime selectedDate)
            {
                // Lấy ngày đã chọn từ DatePicker
                DateTime dateTime = selectedDate;

                // Thêm thời gian hiện tại vào ngày đã chọn
                DateTime fullDateTime = dateTime.Add(DateTime.Now.TimeOfDay);

                // Chuyển đổi sang định dạng ISO 8601 (UTC)
                string formattedDate = fullDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                // In kết quả ra hoặc gán vào thuộc tính cần thiết
                MessageBox.Show($"Formatted Date: {formattedDate}");
            }
        }

        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
