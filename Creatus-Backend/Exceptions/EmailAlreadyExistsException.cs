namespace creatus_backend.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException() : base(string.Format("Email já registrado")) { }
    }
}