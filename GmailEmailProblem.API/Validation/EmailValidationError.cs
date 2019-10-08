namespace GmailEmailProblem.Validation
{
    public class EmailValidationError
    {
        public string Email { get; set; }

        public string Message { get; set; }

        public EmailValidationError(string field, string message)
        {
            Email = field != string.Empty ? field : null;
            Message = message;
        }
    }
}