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
    private uint _currentRound;

    [ObservableProperty]
    private uint _maxRounds;

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
        Pairings = [];
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Calculates the number of rounds based on the number of participants.
    /// </summary>
    private void CalculateMaxRounds()
    {
        MaxRounds = (uint)Math.Ceiling(Math.Log2(Participants.Count));
    }

    /// <summary>
    /// Calculates pairings based on the current participants.
    /// </summary>
    private void CalculatePairings()
    {
        // Sort by score in descending order
        var sortedParticipants = Participants.OrderByDescending(p => p.Score).ToList();
        Pairings.Clear();

        foreach (var participant in sortedParticipants)
        {
            // Skip if participant has already been paired
            if (participant.IsPaired)
            {
                continue;
            }

            IPairing pairing;

            // Find the first other unpaired participant that has not been matched with the participant
            var opponent = sortedParticipants.FirstOrDefault(p => p != participant && !p.IsPaired && !p.OpponentsPlayed.Contains(participant));

            if (opponent == null)
            {
                // If no suitable opponent is found, give the participant a bye.
                pairing = new Pairing(participant);
                participant.IsPaired = true;
                participant.HasReceivedBye = true;
            }
            else
            {
                // Pair the participant with the opponent, recording that they have played each other.
                pairing = new Pairing(participant, opponent);
                participant.IsPaired = true;
                participant.OpponentsPlayed.Add(opponent);
                opponent.IsPaired = true;
                opponent.OpponentsPlayed.Add(participant);
            }

            Pairings.Add(pairing);
        }
    }

    /// <summary>
    /// Adds the round scores to the cumulative total for each participant.
    /// </summary>
    private void CalculateScores()
    {
        foreach (var pairing in Pairings)
        {
            // Calculate score for participant 1.
            // TODO
            pairing.Participant1.Score += pairing.RoundScoreParticipant1;

            // Only calculate score for participant 2 if pairing is not a bye.
            if (pairing.IsBye)
            {
                continue;
            }

            // Calculate score for participant 2.
            pairing.Participant2.Score += pairing.RoundScoreParticipant2;
        }
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

        Participants.Add(new Participant(name)
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
        CalculateMaxRounds();
        CalculatePairings();
        CurrentRound = 1;
    }

    /// <inheritdoc/>
    public void MoveNextRound()
    {
        // Do not advance to next round if we are on the last round.
        if (CurrentRound == MaxRounds)
        {
            return;
        }

        CalculateScores();
        CalculatePairings();
        CurrentRound++;
    }

    #endregion
}