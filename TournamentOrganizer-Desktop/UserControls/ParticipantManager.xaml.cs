using System.Windows;
using System.Windows.Controls;
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

        #endregion

        #region Properties

        /// <summary>
        /// The participant to manage.
        /// </summary>
        public IParticipant Participant
        {
            get { return (IParticipant)GetValue(ParticipantProperty); }
            set { SetValue(ParticipantProperty, value); }
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
