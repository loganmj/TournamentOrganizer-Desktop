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

        // If there are an odd number of participants, give the last participant a bye.
        // Do not give the same participant a bye more than once per tournament.
        if (sortedParticipants.Count % 2 != 0)
        {
            /*

            // Check if the person in last already had a bye
            var byeParticipant = sortedParticipants.LastOrDefault(p => !p.HasReceivedBye);

            // Create a bye pairing
            if (byeParticipant != null)
            {
                Pairings.Add(new Pairing(byeParticipant));
                byeParticipant.HasReceivedBye = true;
                byeParticipant.IsPaired = true;
            }

            */
        }

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

        /*

        // TODO: Match pairings from beginning to end, avoiding matching the same pairings twice.
        for (int i = 0; i < sortedParticipants.Count; i += 2)
        {
            // Exit if no valid pairing can be made.
            // TODO: Think of a better way to handle this.
            if (i + 1 >= sortedParticipants.Count)
            {
                continue;
            }

            // TODO: Avoid repeating pairings
            IPairing pairing;
            var participant1 = sortedParticipants[i];
            var participant2 = sortedParticipants.Skip(i+1).FirstOrDefault(p => !p.OpponentsPlayed.Contains(participant1));

            if (participant2 == null)
            {
                pairing = new Pairing(participant1);
                participant1.HasReceivedBye = true;
            }
            else
            {
                pairing = new Pairing(sortedParticipants[i], participant2);
                participant1.OpponentsPlayed.Add(participant2);
                participant2.OpponentsPlayed.Add(participant1);
            }

            Pairings.Add(pairing);
        }

        */
    }

    /// <summary>
    /// Calculates the new scores for each participant.
    /// </summary>
    private void CalculateScores()
    {
        // TODO
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