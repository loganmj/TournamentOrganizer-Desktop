using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    [ObservableProperty]
    private string _newParticipantNameInput;

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
        NewParticipantNameInput = "John Doe";
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
        State = AppState.TournamentSetup;
    }

    /// <summary>
    /// Handles the Add Participant button being clicked.
    /// </summary>
    [RelayCommand]
    private void OnAddParticipantButtonClick()
    {
        Tournament?.AddParticipant(NewParticipantNameInput);
    }

    /// <summary>
    /// Handles the Start Tournament button being clicked.
    /// </summary>
    [RelayCommand]
    private void OnStartTournamentButtonClick()
    {
        State = AppState.TournamentStarted;
    }

    #endregion
}