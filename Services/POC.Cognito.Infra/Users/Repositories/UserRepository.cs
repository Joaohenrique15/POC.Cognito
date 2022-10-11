using POC.Cognito.Domain.Users.Entities;
using POC.Cognito.Domain.Users.Interfaces.InfraData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Cognito.Infra.Users.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AuthenticationDataContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllTest()
        {
            return await _db.ToListAsync();
        }

        public async Task<User> GetUserByCognitoId(Guid cognitoId)
        {
            return await _db.FirstAsync(x => x.CognitoUserId == cognitoId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
