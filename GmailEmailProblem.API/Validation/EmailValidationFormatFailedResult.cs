using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GmailEmailProblem.Validation
{
    public class EmailValidationFormatFailedResult : ObjectResult
    {
        public EmailValidationFormatFailedResult(EmailValidationResultModel modelState)
            : base(modelState)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}