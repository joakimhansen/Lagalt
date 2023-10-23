namespace Lagalt_backend.Data.Exceptions
{
    public class CollaboratorExistsException : Exception
    {
        public CollaboratorExistsException(string username) : base($"User with username {username} is already a collaborator of this project.")
        {
        }
    }

}
