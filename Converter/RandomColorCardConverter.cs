using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace EngMasterWPF.Converter
{
    class RandomColorCardConverter : IValueConverter
    {
        private static readonly List<string> MaterialColors = new List<string>
    {

"#009688"



        };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var random = new Random();
            var colorHex = MaterialColors[random.Next(MaterialColors.Count)];
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
}
