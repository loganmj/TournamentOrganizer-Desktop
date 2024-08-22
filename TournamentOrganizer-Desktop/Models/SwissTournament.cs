using CommunityToolkit.Mvvm.ComponentModel;

namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// Defines a Swiss style tournament.
/// </summary>
public partial class SwissTournament : ObservableObject, ITournament
{
    #region Properties

    /// <inheritdoc/>
    public uint ID { get; set; }

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
        ID = GenerateUniqueID();
        Name = "";
        Participants = [];
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public SwissTournament(string name)
    {
        ID = GenerateUniqueID();
        Name = name;
        Participants = [];
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Generates a unique ID value.
    /// </summary>
    /// <returns>A unique uint ID value.</returns>
    private uint GenerateUniqueID()
    {
        // TODO
        return 1;
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
        var targetParticipant = Participants.FirstOrDefault(p => p.ID == id);

        if (targetParticipant != null)
        {
            Participants.Remove(targetParticipant);
        }
    }

    #endregion
}