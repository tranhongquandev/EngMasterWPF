﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EngMasterWPF.Converter
{
    public class FeeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                // Định dạng thành chuỗi số với dấu phẩy và thêm "VND"
                return $"{doubleValue:N0} VND";
            }
            if (value is int intValue)
            {
                return $"{intValue:N0} VND";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
