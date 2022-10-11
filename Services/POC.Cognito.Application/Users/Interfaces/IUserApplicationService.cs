using POC.Cognito.Application.Users.ViewModels;
using POC.Cognito.Core.Models;
using POC.Cognito.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Cognito.Application.Users.Interfaces
{
    public interface IUserApplicationService
    {
        Task<Either<ErrorResponseModel, Guid>> AddUserAsync(CreateUserRequestModel createUserRequestModel);
        Task<Either<ErrorResponseModel, object>> LoginAsync(LoginRequestModel loginRequestModel);
        Task<Either<ErrorResponseModel, object>> ChangePasswordAsAdmin(FirstPasswordChangeRequestModel userNameAndPasswordRequestModel);
        Task<Either<ErrorResponseModel, object>> InitiateRecoverPassword(string username);
        Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword);
        Task DeleteUser();
        Task<List<User>> GetAllTeste();

    }
}
