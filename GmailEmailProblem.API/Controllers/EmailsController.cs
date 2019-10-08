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

        [HttpPost("unique")]
        public IActionResult Post([FromBody]IEnumerable<string> emails)
        {
            if (!ModelState.IsValid)
            {
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
