
namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// A participant object.
/// </summary>
public class Participant : IParticipant
{
    #region Constants

    private const string DEFAULT_NAME = "John Doe";

    #endregion

    #region Properties

    /// <inheritdoc/>
    public Guid Id { get; set; }

    /// <inheritdoc/>
    public string Name { get; set; }

    /// <inheritdoc/>
    public bool HasReceivedBye { get; set; }

    /// <inheritdoc/>
    public uint Score { get; set; }

    /// <inheritdoc/>
    public List<IParticipant> OpponentsPlayed { get; set; }

    /// <inheritdoc/>
    public bool IsPaired { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Base constructor.
    /// </summary>
    public Participant()
    {
        Id = Guid.NewGuid();
        Name = DEFAULT_NAME;
        OpponentsPlayed = [];
    }

    /// <summary>
    /// Constructor.
    /// Allows passing in a name.
    /// </summary>
    /// <param name="name"></param>
    public Participant(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        OpponentsPlayed = [];
    }

    #endregion
}
