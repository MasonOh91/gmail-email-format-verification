using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GmailEmailProblem.Validation
{
    /// <summary>
    /// A model representing a listing of errors for all bad email inputs
    /// </summary>
    public class EmailValidationResultModel
    {
        /// <summary>
        /// The overall error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Each individual error for any bad email inputs
        /// </summary>
        public IEnumerable<EmailValidationError> Errors { get; }

        public EmailValidationResultModel(IEnumerable<string> emails)
        {
            Message = "Email Formatting Errors Were Found";
            Errors = emails
                .Where(email => !email.Contains("@"))
                .Select(erroredInput => new EmailValidationError(erroredInput, "Email does not contain an @"))
                .ToList();
        }
    }
}