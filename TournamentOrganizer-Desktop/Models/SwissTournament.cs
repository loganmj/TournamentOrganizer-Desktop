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

    #endregion

    #region Fields

    [ObservableProperty]
    private Guid _id;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private ObservableCollection<IParticipant> _participants;

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
    }

    #endregion

    #region Public Methods

    /// <inheritdoc/>
    public void AddParticipant(IParticipant participant)
    {
        Participants.Add(participant);
    }

    /// <inheritdoc/>
    public void RemoveParticipant(string Name)
    {
        var targetParticipant = Participants.FirstOrDefault(p => p.Name == Name);

        if (targetParticipant != null)
        {
            Participants.Remove(targetParticipant);
        }
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[Swiss Tournament]: ID={Id}, Name={Name}, Participants={string.Join(',', Participants)}";
    }

    #endregion
}