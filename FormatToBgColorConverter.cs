using HomeLibrary;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace tsd_wpf
{
    class FormatToBgColorConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((BookFormat)value)
            {
                case BookFormat.PaperBack:
                    return Brushes.LightGray;
                default:
                    return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
