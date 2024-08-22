namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// Defines a Swiss style tournament.
/// </summary>
public class SwissTournament : ITournament
{
    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public SwissTournament(uing id, string name)
    {
        Id = id;
        Name = name;
        Participants = new List<Participant>();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a participant.
    /// </summary>
    /// <param name="participant"></param>
    public void AddParticipant(IParticipant participant)
    {
        Participants.Add(participant);
    }

    /// <summary>
    /// Removes a participant from the tournament.
    /// </summary>
    /// <param name="id"></param>
    public void RemoveParticipant(uint id)
    {
        var targetParticipant = Participants.FirstOrDefault(p => p.Id == id);

        if (targetParticipant != null)
        {
            Participants.Remove(targetParticipant);
        }
    }

    #endregion
}