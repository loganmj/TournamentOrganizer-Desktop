namespace TournamentOrganizer_Desktop.Models;

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
    /// Has the participant received a bye.
    /// </summary>
    bool HasReceivedBye { get; set; }

    /// Tracks the cumulative tournament score of the participant.
    /// </summary>
    uint Score { get; set; }

    /// <summary>
    /// Tracks the opponents that the participant has been paired with.
    /// </summary>
    List<IParticipant> OpponentsPlayed { get; set; }

    /// <summary>
    /// Has the participant been paired this round.
    /// </summary>
    bool IsPaired { get; set; }

    #endregion
}