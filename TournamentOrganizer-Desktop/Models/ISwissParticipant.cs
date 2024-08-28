namespace TournamentOrganizer_Desktop.Models
{
    public interface ISwissParticipant : IParticipant
    {
        #region Properties

        /// <summary>
        /// Tracks the cumulative tournament score of the participant.
        /// </summary>
        uint Score { get; set; }

        /// <summary>
        /// Tracks the opponents that the participant has been paired with.
        /// </summary>
        List<IParticipant> OpponentsPlayed { get; set; }

        #endregion
    }
}
