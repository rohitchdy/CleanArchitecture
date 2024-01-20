using Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Serilog;
using System.Diagnostics;

namespace Api.Errors;

public class CleanArchitecureProblemDetalsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;
    public CleanArchitecureProblemDetalsFactory(IOptions<ApiBehaviorOptions> options)
    {
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        var problemValidationDetails = new ValidationProblemDetails(modelState: modelStateDictionary)
        {
            Instance = httpContext.Request.Path,
            Status = StatusCodes.Status400BadRequest,
        };

        if (_options.ClientErrorMapping.TryGetValue((int)problemValidationDetails.Status, out var clientErrorData))
        {
            problemValidationDetails.Type ??= clientErrorData.Link;
            problemValidationDetails.Extensions["traceId"] = httpContext.TraceIdentifier;
        }
        Log.Error("Validation Error: {@ProblemValidationDetails} ", problemValidationDetails);
        return problemValidationDetails;
    }
    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
    {
        statusCode = statusCode ?? throw new ArgumentNullException(nameof(statusCode));
        var problemDetails = new ProblemDetails
        {
            Title = title,
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = httpContext.Request.Path
        };
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode);
        return problemDetails;

    }

    public void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int? statusCode)
    {
        problemDetails.Status ??= statusCode;
        if (_options.ClientErrorMapping.TryGetValue(key: (int)statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;

            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }
            var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
            if (errors is not null)
            {
                problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));

            }
        }
        Log.Error("Error: {@ProblemDetails}", problemDetails);

    }
}
