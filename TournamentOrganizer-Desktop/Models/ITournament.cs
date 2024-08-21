namespace TournamentOrganizer_Desktop.Models
{
    /// <summary>
    /// An interface for a tournament object.
    /// </summary>
    public interface ITournament
    {
        #region Properties

        /// <summary>
        /// A list of all participants in the tournament.
        /// </summary>
        List<IParticipant> Participants { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a participant to the tournament.
        /// </summary>
        /// <param name="participant"></param>
        void AddParticipant(IParticipant participant);

        /// <summary>
        /// Removes a participant from the tournament.
        /// </summary>
        /// <param name="ID"></param>
        void RemoveParticipant(uint ID);

        #endregion
    }
}