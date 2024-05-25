namespace PasswordManagerWPF.Utilities;

using System;
using System.Globalization;
using System.Windows.Data;

public class RangeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double progress)
        {
            if (progress <= 25) return "Red";
            if (progress <= 50) return "Orange";
            if (progress <= 75) return "Yellow";
            return "Green";
        }
        return "Gray";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
