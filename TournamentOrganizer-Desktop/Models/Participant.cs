
namespace TournamentOrganizer_Desktop.Models
{
    /// <summary>
    /// A participant object.
    /// </summary>
    public class SwissParticipant : IParticipant
    {
        #region Constants

        private const string DEFAULT_NAME = "John Doe";

        #endregion

        #region Properties

        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public uint ParticipantNumber { get; set; }

        /// <inheritdoc/>
<<<<<<< HEAD
        public bool HasReceivedBye { get; set; }
=======
        public uint Score { get; set; }

        /// <inheritdoc/>
        public List<IParticipant> OpponentsPlayed { get; set; }
>>>>>>> cb5d4af0efabfefbc2c710eba69b7c886d0346d3

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor.
        /// </summary>
        public SwissParticipant()
        {
            Id = Guid.NewGuid();
            Name = DEFAULT_NAME;
            ParticipantNumber = 0;
            Score = 0;
            OpponentsPlayed = [];
        }

        /// <summary>
        /// Constructor.
        /// Allows passing in a name.
        /// </summary>
        /// <param name="name"></param>
        public SwissParticipant(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            ParticipantNumber = 0;
            Score = 0;
            OpponentsPlayed = [];
        }

        #endregion
    }
}
