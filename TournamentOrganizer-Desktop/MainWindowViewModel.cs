using TournamentOrganizer_Desktop.ViewModels;

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
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "Tournament Organizer";
        }

        #endregion
    }
}