using System.Globalization;
using System.Windows.Data;

namespace TournamentOrganizer_Desktop.ViewModels;

/// <summary>
/// Inverts a boolean value.
/// </summary>
class BooleanInverter : IValueConverter
{
    #region Public Methods

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool boolValue ? !boolValue : (object)false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool boolValue ? !boolValue : (object)false;
    }

    #endregion
}
