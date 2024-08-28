namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// Defines an interface for a pairing.
/// </summary>
public interface IPairing
{
    #region Properties

    /// <summary>
    /// The first participant.
    /// </summary>
    IParticipant Participant1 { get; set; }

    /// <summary>
    /// The second participant.
    /// </summary>
    IParticipant Participant2 { get; set; }

    /// <summary>
    /// Is the pairing a bye.
    /// </summary>
    bool IsBye { get; set; }

    #endregion
}
