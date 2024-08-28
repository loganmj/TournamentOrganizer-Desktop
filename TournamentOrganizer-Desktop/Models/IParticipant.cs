namespace TournamentOrganizer_Desktop.Models
{
    /// <summary>
    /// An interface for a tournament participant.
    /// </summary>
    public interface IParticipant
    {
        #region Properties

        /// <summary>
        /// A unique ID number for the participant.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// The name of the participant.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// A number given to a participant, localized to a specific tournament.
        /// </summary>
        uint ParticipantNumber { get; set; }

        /// <summary>
        /// Has the participant received a bye.
        /// </summary>
        bool HasReceivedBye { get; set; }

        #endregion
    }
}