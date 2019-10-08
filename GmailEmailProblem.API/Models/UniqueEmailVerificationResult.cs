using System.Collections.Generic;

namespace GmailEmailProblemAPI.Models
{
    /// <summary>
    /// A model that represents the result of email unique verification
    /// </summary>
    public class UniqueEmailVerificationResult
    {
        /// <summary>
        /// All of the emails that are unique within the set, with extra characters (+ and . in the username) removed
        /// </summary>
        public IEnumerable<string> UniqueEmails { get; set; }

        /// <summary>
        /// The count of UniqueEmails
        /// </summary>
        public int Count { get; set; }
    }
}
