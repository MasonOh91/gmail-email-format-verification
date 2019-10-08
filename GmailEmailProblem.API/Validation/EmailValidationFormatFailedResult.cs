using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GmailEmailProblem.Validation
{
    /// <summary>
    /// An ObjectResult for our email formatting errors, returns a 422
    /// </summary>
    public class EmailValidationFormatFailedResult : ObjectResult
    {
        public EmailValidationFormatFailedResult(EmailValidationResultModel modelState)
            : base(modelState)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}