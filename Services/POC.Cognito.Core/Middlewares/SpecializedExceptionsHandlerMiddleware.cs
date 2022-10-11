using Amazon.CognitoIdentityProvider.Model;
using POC.Cognito.Core.Models;
using POC.Cognito.Core.Models.Errors;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace POC.Cognito.Core.Middlewares
{
    public class SpecializedExceptionsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public SpecializedExceptionsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainErrorException domainException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new ErrorResponseModel("One or more errors occurred", domainException.Message));
            }
            catch (NotAuthorizedException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new ErrorResponseModel("One or more errors occurred", ErrorConstants.WRONG_PASSWORD));
            }
            catch (UsernameExistsException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new ErrorResponseModel("One or more errors occurred", ErrorConstants.USER_ALREADY_EXISTS));
            }
        }
    }
}
