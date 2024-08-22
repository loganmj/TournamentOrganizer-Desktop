namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// An interface for a tournament object.
/// </summary>
public interface ITournament
{
    #region Properties

    /// <summary>
    /// The unique ID value of the tournament.
    /// </summary>
    Guid ID { get; set; }

    /// <summary>
    /// The name of the tournament.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// A list of all participants in the tournament.
    /// </summary>
    List<IParticipant> Participants { get; set; }

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