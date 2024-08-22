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
}