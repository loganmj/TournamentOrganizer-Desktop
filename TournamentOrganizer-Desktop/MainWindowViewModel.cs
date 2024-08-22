using TournamentOrganizer_Desktop.ViewModels;
using TournamentOrganizer_Desktop.Models;
using CommunityToolkit.Mvvm.ComponentModel;

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
}