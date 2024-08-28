
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
        public uint Score { get; set; }

        /// <inheritdoc/>
        public List<IParticipant> OpponentsPlayed { get; set; }

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
