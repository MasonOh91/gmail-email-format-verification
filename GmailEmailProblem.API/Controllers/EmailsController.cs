using System.Collections.Generic;
using System.Linq;
using GmailEmailProblem.Validation;
using GmailEmailProblemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GmailEmailProblem.Controllers
{
    /// <summary>
    /// Controller for all email API calls
    /// </summary>
    [Route("api/[controller]")]
    public class EmailsController : Controller
    {
        private readonly IEmailFormatVerificationService _emailFormatVerificationService;

        public EmailsController(IEmailFormatVerificationService emailFormatVerificationService)
        {
            _emailFormatVerificationService = emailFormatVerificationService;
        }

        /// <summary>
        /// Our endpoint for this exercise, feed this emails via a POST body and receive
        /// a listing of unique emails per the gmail formatting rules, with some very baseline
        /// input validation.
        /// </summary>
        /// <param name="emails">The input emails</param>
        /// <returns>IActionResult of the api endpoint</returns>
        [HttpPost("unique")]
        public IActionResult Post([FromBody]IEnumerable<string> emails)
        {
            if (!ModelState.IsValid)
            {
                // TODO: sounds like the WC3 thing is to process all of this stuff as a 422?
                //       research and come back to this.
                return BadRequest();
            }
            var emailsErrors = new EmailValidationResultModel(emails);
            if (emailsErrors.Errors.Any())
            {
                return new EmailValidationFormatFailedResult(emailsErrors);
            }
            var emailVerificationResults = _emailFormatVerificationService.GetUniqueEmails(emails);
            return Ok(emailVerificationResults);
        }
    }
}
