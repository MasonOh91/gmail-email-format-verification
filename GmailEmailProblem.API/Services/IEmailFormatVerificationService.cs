using System.Collections.Generic;
using GmailEmailProblemAPI.Models;

namespace GmailEmailProblemAPI.Services
{
    /// <summary>
    /// A service that represents email formatting verification
    /// </summary>
    public interface IEmailFormatVerificationService
    {
        /// <summary>
        /// Verifies that the list of emails passed in are unique
        /// </summary>
        /// <param name="emails">A list of emails</param>
        /// <returns>A UniqueEmailVerificationResult, with a detailed account of the unique emails</returns>
        UniqueEmailVerificationResult GetUniqueEmails(IEnumerable<string> emails);
    }
}
