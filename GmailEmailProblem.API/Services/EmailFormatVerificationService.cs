using System.Collections.Generic;
using System.Linq;
using GmailEmailProblemAPI.Models;

namespace GmailEmailProblemAPI.Services
{
    public class EmailFormatVerificationService : IEmailFormatVerificationService
    {
        // TODO: Implement a DB connection and repo DI, and implement signup logic

        public UniqueEmailVerificationResult GetUniqueEmails(IEnumerable<string> emails)
        {
            var cleanedEmails = emails
                .Select(email =>
                {
                    var username = email.Split("@").First();
                    var domain = email.Split("@").Last();
                    var cleanedUsername = username.Split("+").First().Replace(".", "");
                    return $"{cleanedUsername}@{domain}";
                })
                .Distinct()
                .ToList();

            return new UniqueEmailVerificationResult
            {
                Count = cleanedEmails.Count,
                UniqueEmails = cleanedEmails
            };
        }
    }
}
