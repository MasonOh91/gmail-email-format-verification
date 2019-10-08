using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GmailEmailProblem.Validation
{
    public class EmailValidationResultModel
    {
        public string Message { get; set; }

        public IEnumerable<EmailValidationError> Errors { get; set; }

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