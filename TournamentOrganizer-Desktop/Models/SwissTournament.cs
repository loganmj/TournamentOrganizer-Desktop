using CommunityToolkit.Mvvm.ComponentModel;

namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// Defines a Swiss style tournament.
/// </summary>
public partial class SwissTournament : ObservableObject, ITournament
{
    #region Constants

    /// <summary>
    /// Default tournament name.
    /// </summary>
    private const string DEFAULT_NAME = "New Tournament";

    #endregion

    #region Properties

    /// <inheritdoc/>
    public Guid ID { get; set; }

    /// <inheritdoc/>
    public string Name { get; set; }

    /// <inheritdoc/>
    public List<IParticipant> Participants { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Base constructor
    /// </summary>
    public SwissTournament()
    {
        ID = Guid.NewGuid();
        Name = DEFAULT_NAME;
        Participants = [];
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public SwissTournament(string name)
    {
        ID = Guid.NewGuid();
        Name = name ?? DEFAULT_NAME;
        Participants = [];
    }

    #endregion

    #region Public Methods

    /// <inheritdoc/>
    public void AddParticipant(IParticipant participant)
    {
        Participants.Add(participant);
    }

    /// <inheritdoc/>
    public void RemoveParticipant(uint id)
    {
        var targetParticipant = Participants.FirstOrDefault(p => p.ID == id);

        if (targetParticipant != null)
        {
            Participants.Remove(targetParticipant);
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[Swiss Tournament]: ID={ID}, Name={Name}, Participants={string.Join(',', Participants)}";
    }

    #endregion
}