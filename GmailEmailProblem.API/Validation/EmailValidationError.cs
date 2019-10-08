namespace GmailEmailProblem.Validation
{
    /// <summary>
    /// Represents an error for a single email in the list of inputs
    /// </summary>
    public class EmailValidationError
    {
        /// <summary>
        /// The email that observes some kind of error
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; }

        public EmailValidationError(string field, string message)
        {
            Email = field != string.Empty ? field : null;
            Message = message;
        }
    }
}