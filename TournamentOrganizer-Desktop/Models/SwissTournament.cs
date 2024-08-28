using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

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

    /// <summary>
    /// The maximum number of participants.
    /// </summary>
    private const uint MAX_PARTICIPANTS = 1000;

    #endregion

    #region Fields

    [ObservableProperty]
    private Guid _id;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private ObservableCollection<IParticipant> _participants;

    [ObservableProperty]
    private uint _rounds;

    [ObservableProperty]
    private ObservableCollection<IPairing> _pairings;

    #endregion

    #region Constructors

    /// <summary>
    /// Base constructor
    /// </summary>
    public SwissTournament()
    {
        Id = Guid.NewGuid();
        Name = DEFAULT_NAME;
        Participants = [];
        Rounds = 0;
        Pairings = [];
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public SwissTournament(string name)
    {
        Id = Guid.NewGuid();
        Name = name ?? DEFAULT_NAME;
        Participants = [];
        Rounds = 0;
        Pairings = [];
    }

    #endregion

    #region Public Methods

    /// <inheritdoc/>
    public void AddParticipant(string name)
    {
        // Don't add participant if tournament is full.
        if (Participants.Count >= MAX_PARTICIPANTS)
        {
            return;
        }

        Participants.Add(new SwissParticipant(name)
        {
            ParticipantNumber = (uint)Participants.Count
        });
    }

    /// <inheritdoc/>
    public void RemoveParticipant(Guid id)
    {
        var targetParticipant = Participants.FirstOrDefault(p => p.Id == id);

        if (targetParticipant == null)
        {
            return;
        }

        Participants.Remove(targetParticipant);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[Swiss Tournament]: ID={Id}, Name={Name}, Participants={string.Join(',', Participants)}";
    }

    /// <inheritdoc/>
    public void StartTournament()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void MoveNextRound()
    {
        throw new NotImplementedException();
    }

    #endregion
}