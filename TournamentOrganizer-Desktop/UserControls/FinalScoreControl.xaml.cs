using System.Windows;
using System.Windows.Controls;
using TournamentOrganizer_Desktop.Models;

namespace TournamentOrganizer_Desktop.UserControls;

/// <summary>
/// Interaction logic for FinalScoreControl.xaml
/// </summary>
public partial class FinalScoreControl : UserControl
{
    #region Dependency Properties

    /// <summary>
    /// Exposes the Participant property as a dependency property.
    /// </summary>
    public static readonly DependencyProperty ParticipantProperty =
    DependencyProperty.Register(
        nameof(Participant),
        typeof(IParticipant),
        typeof(FinalScoreControl),
        new PropertyMetadata(null));

    #endregion

    #region Properties

    /// <summary>
    /// The participant to manage.
    /// </summary>
    public IParticipant Participant
    {
        get => (IParticipant)GetValue(ParticipantProperty);
        set => SetValue(ParticipantProperty, value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    public FinalScoreControl()
    {
        InitializeComponent();
    }

    #endregion
}
