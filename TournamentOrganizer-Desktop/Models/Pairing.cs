using CommunityToolkit.Mvvm.ComponentModel;

namespace TournamentOrganizer_Desktop.Models;

/// <summary>
/// Implements a tournament pairing.
/// </summary>
public partial class Pairing : ObservableObject, IPairing
{
    #region Fields

    [ObservableProperty]
    private IParticipant _participant1;

    [ObservableProperty]
    private IParticipant _participant2;

    [ObservableProperty]
    private bool _isBye;

    [ObservableProperty]
    private uint _roundScoreParticipant1;

    [ObservableProperty]
    private uint _roundScoreParticipant2;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructs a bye pairing with a single participant.
    /// </summary>
    /// <param name="participant1"></param>
    public Pairing(IParticipant participant1)
    {
        Participant1 = participant1;
        Participant2 = new Participant("BYE");
        IsBye = true;
        RoundScoreParticipant1 = 2;
        RoundScoreParticipant2 = 0;
    }

    /// <summary>
    /// Constructs a pairing with two participants.
    /// </summary>
    /// <param name="participant1"></param>
    /// <param name="participant2"></param>
    public Pairing(IParticipant participant1, IParticipant participant2)
    {
        Participant1 = participant1;
        Participant2 = participant2;
    }

    #endregion
}
