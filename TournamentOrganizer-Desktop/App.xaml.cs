using System.Configuration;
using System.Data;
using System.Windows;

namespace TournamentOrganizer_Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    #region Fields

    private MainWindowViewModel? _mainWindowViewModel;
    private MainWindow? _mainWindow;

    #endregion

    #region Event Handlers

    /// <summary>
    /// Code that runs at startup.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        _mainWindowViewModel = new MainWindowViewModel();
        _mainWindow = new MainWindow(_mainWindowViewModel);
        _mainWindow.Show();
    }

    #endregion
}

