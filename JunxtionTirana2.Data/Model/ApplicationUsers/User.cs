namespace JunxtionTirana2.Model.ApplicationUsers
{
    public class User
    {
        /// <summary>
        /// The identifier of the user
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The username of the user
        /// </summary>
        public string? Username { get; set; }
        /// <summary>
        /// The avatar id of the user
        /// </summary>
        public int AvatarId { get; set; }
        /// <summary>
        /// Education of the user
        /// </summary>
        public string? Education { get; set; }
        /// <summary>
        /// Email adress of the user
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Profile description of the user
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The skills of the user
        /// </summary>
        public List<string?>? Skills { get; set; }
    }
}
