﻿using System;
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
    /// Interaction logic for ModalCourse.xaml
    /// </summary>
    public partial class ModalCourse : UserControl
    {
        public ModalCourse()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}