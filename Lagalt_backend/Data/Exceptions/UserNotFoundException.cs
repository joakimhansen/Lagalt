namespace Lagalt_backend.Data.Exceptions {

    /// <summary>
    /// Exception to be thrown when a user could not be found
    /// </summary>
    public class UserNotFoundException : Exception {
        public UserNotFoundException(string username) : base($"User with username {username} could not be found.") {
        }
    }
}
