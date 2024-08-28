namespace TournamentOrganizer_Desktop.Models
{
    /// <summary>
    /// A participant object.
    /// </summary>
    internal class Participant : IParticipant
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
        public bool HasReceivedBye { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Participant()
        {
            Id = Guid.NewGuid();
            Name = DEFAULT_NAME;
        }

        /// <summary>
        /// Constructor.
        /// Allows passing in a name.
        /// </summary>
        /// <param name="name"></param>
        public Participant(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }



        #endregion
    }
}
