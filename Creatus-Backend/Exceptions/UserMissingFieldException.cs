namespace creatus_backend.Exceptions
{
    public class UserMissingFieldException : Exception
    {
        public UserMissingFieldException(String message) : base(string.Format(message)) { }
    }
}