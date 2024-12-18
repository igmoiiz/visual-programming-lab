using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Inventory_Management_System___Design_2
{
	public class LengthToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int length)
			{
				return length > 0 ? Visibility.Collapsed : Visibility.Visible;
			}
			return Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}