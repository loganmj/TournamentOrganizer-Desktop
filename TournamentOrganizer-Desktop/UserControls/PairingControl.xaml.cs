using System.Windows;
using System.Windows.Controls;
using TournamentOrganizer_Desktop.Models;

namespace TournamentOrganizer_Desktop.UserControls;

/// <summary>
/// Interaction logic for PairingControl.xaml
/// </summary>
public partial class PairingControl : UserControl
{
    #region Constants

    /// <summary>
    /// The max score a participant can have.
    /// </summary>
    private const uint MAX_SCORE = 2;

    #endregion

    #region Dependency Properties

    /// <summary>
    /// Exposes the Participant property as a dependency property.
    /// </summary>
    public static readonly DependencyProperty PairingProperty =
    DependencyProperty.Register(
        nameof(Pairing),
        typeof(IPairing),
        typeof(PairingControl),
        new PropertyMetadata(null));

    #endregion

    #region Properties

    /// <summary>
    /// A reference to the pairing.
    /// </summary>
    public IPairing Pairing
    {
        get => (IPairing)GetValue(PairingProperty);
        set => SetValue(PairingProperty, value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="pairing"></param>
    public PairingControl()
    {
        InitializeComponent();
    }

    #endregion

    #region Event Handlers

    /// <summary>
    /// Increments the score for Participant 1.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScoreCounterButton_Click_Participant1(object sender, RoutedEventArgs e)
    {
        if (Pairing.RoundScoreParticipant1 < MAX_SCORE)
        {
            Pairing.RoundScoreParticipant1++;
            return;
        }

        Pairing.RoundScoreParticipant1 = 0;
    }

    /// <summary>
    /// Increments the score for Participant 2.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScoreCounterButton_Click_Participant2(object sender, RoutedEventArgs e)
    {
        if (Pairing.RoundScoreParticipant2 < MAX_SCORE)
        {
            Pairing.RoundScoreParticipant2++;
            return;
        }

        Pairing.RoundScoreParticipant2 = 0;
    }

    #endregion
}
