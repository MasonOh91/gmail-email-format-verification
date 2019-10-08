using System.Collections.Generic;

namespace GmailEmailProblemAPI.Models
{
    /// <summary>
    /// A model that represents the result of email unique verification
    /// </summary>
    public class UniqueEmailVerificationResult
    {
        public IEnumerable<string> UniqueEmails { get; set; }

        public int Count { get; set; }
    }
}
