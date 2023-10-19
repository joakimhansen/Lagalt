namespace Lagalt_backend.Data.Exceptions {

    /// <summary>
    /// Exception to be thrown when an entity could not be found
    /// </summary>
    public class EntityNotFoundException : Exception {
        public EntityNotFoundException(string type, int id) : base($"{type} with Id: {id} could not be found.") {
        }
    }
}
