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
    private void CreateTournament()
    {
        Tournament = new SwissTournament(TournamentNameInput);
        State = AppState.TournamentSetup;
    }

    /// <summary>
    /// Handles the Add Participant button being clicked.
    /// </summary>
    [RelayCommand]
    private void AddParticipant()
    {
        Tournament?.AddParticipant(NewParticipantNameInput);
    }

    [RelayCommand]
    private void RemoveParticipant(IParticipant participant)
    {
        Tournament?.RemoveParticipant(participant.Id);
    }

    /// <summary>
    /// Handles the Start Tournament button being clicked.
    /// </summary>
    [RelayCommand]
    private void StartTournament()
    {
        Tournament?.StartTournament();
        State = AppState.TournamentStarted;
    }

    /// <summary>
    /// Handles the NextRound button being clicked.
    /// </summary>
    [RelayCommand]
    private void MoveNextRound()
    {
        // Check if any pairings have not received scores.
        if (Tournament?.Pairings.FirstOrDefault(pairings => pairings.RoundScoreParticipant1 == 0 && pairings.RoundScoreParticipant2 == 0) != null)
        {
            var result = MessageBox.Show($"One or more pairings have not received any points, are you sure you want to move to the next round?", "Next Round", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                return;
            }
        }

        Tournament?.MoveNextRound();
    }

    #endregion
}