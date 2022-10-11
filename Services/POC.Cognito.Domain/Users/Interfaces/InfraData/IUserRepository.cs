using POC.Cognito.Core.Interfaces;
using POC.Cognito.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Cognito.Domain.Users.Interfaces.InfraData
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByCognitoId(Guid cognitoId);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllTest();
    }
}
