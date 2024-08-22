using TournamentOrganizer_Desktop.ViewModels;
using TournamentOrganizer_Desktop.Models;

namespace TournamentOrganizer_Desktop
{
    /// <summary>
    /// A view model for the main window.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private ITournament _tournament;

        #endregion

        #region Properties

        /// <summary>
        /// The referenced tournament object.
        /// The app is only allowed to run one tournament at a time.
        /// </summary>
        public ITournament Tournament
        {
            get => _tournament;
            set => SetProperty(ref _tournament, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "Tournament Organizer";
            _tournament = new SwissTournament(1, "My Swiss Tournament");
        }

        #endregion
    }
}