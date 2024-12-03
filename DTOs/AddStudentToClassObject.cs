using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EngMasterWPF.DTOs
{
    public class AddStudentToClassObject : DependencyObject
    {
        public static readonly DependencyProperty BackgroundProperty =
          DependencyProperty.Register(
              "Background",
              typeof(string),
              typeof(AddStudentToClassObject),
              new PropertyMetadata("#D89084")
          );

        // Tạo DependencyProperty cho IconKind
        public static readonly DependencyProperty IconKindProperty =
            DependencyProperty.Register(
                "IconKind",
                typeof(string),
                typeof(AddStudentToClassObject),
                new PropertyMetadata("UserAdd")
            );

        public string Id { get; set; }

        public string Background
        {
            get => (string)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public string IconKind
        {
            get => (string)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }
    }
}
