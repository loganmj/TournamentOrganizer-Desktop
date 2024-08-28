using System.Collections.ObjectModel;

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
    Guid Id { get; set; }

    /// <summary>
    /// The name of the tournament.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// A list of all participants in the tournament.
    /// </summary>
    ObservableCollection<IParticipant> Participants { get; set; }

    /// <summary>
    /// The number of rounds in the tournament.
    /// </summary>
    uint Rounds { get; set; }

    /// <summary>
    /// The pairings.
    /// </summary>
    ObservableCollection<IPairing> Pairings { get; set; }

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
    /// <param name="Name"></param>
    void RemoveParticipant(string Name);

    /// <summary>
    /// Starts the tournament and calculates pairings for the first round.
    /// </summary>
    void StartTournament();

    /// <summary>
    /// Tallies scores and calculates pairings for the next round of the tournament.
    /// </summary>
    void MoveNextRound();

    #endregion
}