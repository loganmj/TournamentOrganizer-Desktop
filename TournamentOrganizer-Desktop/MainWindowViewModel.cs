using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using TournamentOrganizer_Desktop.Models;
using TournamentOrganizer_Desktop.ViewModels;

namespace TournamentOrganizer_Desktop;

/// <summary>
/// A view model for the main window.
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    #region Fields

    [ObservableProperty]
    private ITournament? _tournament;

    [ObservableProperty]
    private string _tournamentNameInput;

    [ObservableProperty]
    private AppState _state;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    public MainWindowViewModel()
    {
        Title = "Tournament Organizer";
        TournamentNameInput = "New Tournament";
        State = AppState.AppStarted;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Handles the Create button being clicked.
    /// </summary>
    [RelayCommand]
    private void OnCreateButtonClick()
    {
        Tournament = new SwissTournament(TournamentNameInput);
        State = AppState.TournamentStarted;
    }

    #endregion
}