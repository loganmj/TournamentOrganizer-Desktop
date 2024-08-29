using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TournamentOrganizer_Desktop.Models;

namespace TournamentOrganizer_Desktop.UserControls
{
    /// <summary>
    /// Interaction logic for ParticipantManager.xaml
    /// </summary>
    public partial class ParticipantManager : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Exposes the Participant property as a dependency property.
        /// </summary>
        public static readonly DependencyProperty ParticipantProperty =
        DependencyProperty.Register(
            nameof(Participant),
            typeof(IParticipant),
            typeof(ParticipantManager),
            new PropertyMetadata(null));

        /// <summary>
        /// Exposes a RemoveParticipant command as a dependency property
        /// </summary>
        public static readonly DependencyProperty RemoveParticipantProperty =
    DependencyProperty.Register(
        nameof(RemoveParticipant),
        typeof(ICommand),
        typeof(ParticipantManager),
        new PropertyMetadata(null));

        #endregion

        #region Commands

        /// <summary>
        /// Command to remove the Participant.
        /// </summary>
        public ICommand RemoveParticipant
        {
            get => (ICommand)GetValue(RemoveParticipantProperty);
            set => SetValue(RemoveParticipantProperty, value);
        }

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
        /// Parameterless constructor.
        /// </summary>
        public ParticipantManager()
        {
            InitializeComponent();
        }

        #endregion
    }
}
