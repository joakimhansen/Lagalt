namespace Lagalt_backend.Data.Exceptions {
    public class UserNotFoundException : Exception {
        public UserNotFoundException(string username) : base($"User with username {username} could not be found.") {
        }
    }
}
