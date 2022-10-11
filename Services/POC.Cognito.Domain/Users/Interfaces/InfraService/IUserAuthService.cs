using POC.Cognito.Core.Models;
using System.Threading.Tasks;

namespace POC.Cognito.Domain.Users.Interfaces.InfraService
{
    public interface IUserAuthService
    {
        Task RemoveUserAsync(string userName);
        Task CreateUserAsync(Entities.User user);
        Task<Either<ErrorResponseModel, object>> AdminUpdateUserPasswordAsync(string username, string newPassword, string oldPassword);
        Task<Either<ErrorResponseModel, object>> LoginAsync(string username, string password);
        Task<Either<ErrorResponseModel, object>> LoginRefreshTokenAsync(string refreshToken);
        Task<Either<ErrorResponseModel, object>> SendForgotPasswordCodeAsync(string CognitoUsername, string name);
        Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword);
    }
}
