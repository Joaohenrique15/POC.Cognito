using POC.Cognito.Application.Users.Interfaces;
using POC.Cognito.Application.Users.ViewModels;
using POC.Cognito.Core.Models;
using POC.Cognito.Core.Models.Errors;
using POC.Cognito.Core.Models.ValueObjects;
using POC.Cognito.Domain.Users.Entities;
using POC.Cognito.Domain.Users.Interfaces.InfraData;
using POC.Cognito.Domain.Users.Interfaces.InfraService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace POC.Cognito.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserAuthService _userAuthService; 
        private readonly IUserRepository _userRepository;

        public UserApplicationService(IUserAuthService userAuthService, IUserRepository userRepository)
        {
            _userAuthService = userAuthService;
            _userRepository = userRepository;
        }

        public async Task<Either<ErrorResponseModel, Guid>> AddUserAsync(CreateUserRequestModel createUserRequestModel)
        {
            var addressVO = new AddressVO(createUserRequestModel.Address.CEP, createUserRequestModel.Address.Street,
                                           createUserRequestModel.Address.Neighborhood, createUserRequestModel.Address.City,
                                           createUserRequestModel.Address.State);
            var user = new User(createUserRequestModel.Name, createUserRequestModel.CPF,
                                createUserRequestModel.PhoneNumber, createUserRequestModel.Gender, createUserRequestModel.Email,
                                createUserRequestModel.BirthDate, createUserRequestModel.UserType, addressVO);

            await _userAuthService.CreateUserAsync(user);

            await _userRepository.AddAsync(user);
            return new Either<ErrorResponseModel, Guid>(user.Id, HttpStatusCode.OK);
        }

        public Task<Either<ErrorResponseModel, object>> ChangePasswordAsAdmin(FirstPasswordChangeRequestModel userNameAndPasswordRequestModel)
        {
            throw new NotImplementedException();
        }

        public async Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword)
        {
            return await _userAuthService.ConfirmPasswordRecover(username, code, newPassword);
        }

        public Task DeleteUser()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllTeste()
        {
           return await _userRepository.GetAllTest();
        }

        public async Task<Either<ErrorResponseModel, object>> InitiateRecoverPassword(string username)
        {
            var user = await _userRepository.GetUserByEmail(username);
            if (user == null)
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel("", ErrorConstants.USER_NOT_FOUND), HttpStatusCode.BadRequest);
            return await _userAuthService.SendForgotPasswordCodeAsync(username, user.Name);
        }

        public async Task<Either<ErrorResponseModel, object>> LoginAsync(LoginRequestModel loginRequestModel)
        {
            if (loginRequestModel.LoginFlow == ELoginFlow.Credentials)
                return await _userAuthService.LoginAsync(loginRequestModel.Username, loginRequestModel.Password);
            else
                return await _userAuthService.LoginRefreshTokenAsync(loginRequestModel.RefreshToken);
        }
    }
}
