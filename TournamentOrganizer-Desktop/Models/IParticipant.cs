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
<<<<<<< HEAD
        /// Has the participant received a bye.
        /// </summary>
        bool HasReceivedBye { get; set; }
=======
        /// Tracks the cumulative tournament score of the participant.
        /// </summary>
        uint Score { get; set; }

        /// <summary>
        /// Tracks the opponents that the participant has been paired with.
        /// </summary>
        List<IParticipant> OpponentsPlayed { get; set; }
>>>>>>> cb5d4af0efabfefbc2c710eba69b7c886d0346d3

        #endregion
    }
}