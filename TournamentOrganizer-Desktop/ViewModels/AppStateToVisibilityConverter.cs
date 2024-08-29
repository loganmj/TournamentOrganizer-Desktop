using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TournamentOrganizer_Desktop.ViewModels;

/// <summary>
/// Returns a visibility value based on the passed in app state, and a determining match value.
/// </summary>
public class AppStateToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Compares the app state to the passed in value.
    /// If the values match, the component is visible. 
    /// Otherwise the component is collapsed.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns>A Visibility value.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is AppState appState && parameter is AppState targetState)
        {
            return appState == targetState ? Visibility.Visible : Visibility.Collapsed;
        }

        return Visibility.Collapsed;
    }

    /// <summary>
    /// Not used.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
