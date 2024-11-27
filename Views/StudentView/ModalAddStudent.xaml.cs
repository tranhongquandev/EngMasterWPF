using System;
using System.Collections.Generic;
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
    }
}
