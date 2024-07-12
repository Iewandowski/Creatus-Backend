namespace creatus_backend.Exceptions
{
    public class PdfGenerationException : Exception
    {
        public PdfGenerationException(String message, Exception e) : base(string.Format(message), e) { }
    }
}