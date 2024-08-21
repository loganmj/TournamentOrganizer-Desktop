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
        uint ID { get; set; }

        /// <summary>
        /// The name of the participant.
        /// </summary>
        string Name { get; set; }

        #endregion
    }
}