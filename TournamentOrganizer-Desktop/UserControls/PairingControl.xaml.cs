using System.Windows;
using System.Windows.Controls;
using TournamentOrganizer_Desktop.Models;

namespace TournamentOrganizer_Desktop.UserControls;

/// <summary>
/// Interaction logic for PairingControl.xaml
/// </summary>
public partial class PairingControl : UserControl
{
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
}
