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

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    public MainWindowViewModel()
    {
        Title = "Tournament Organizer";
        _tournamentNameInput = "New Tournament";
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

        MessageBox.Show($"Created new tournament with ID={Tournament.ID}, Name={Tournament.Name}");
    }

    #endregion
}