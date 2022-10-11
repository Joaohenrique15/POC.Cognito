using POC.Cognito.Core.Entities;
using POC.Cognito.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Cognito.Domain.Users.Entities
{
    public class UserAddress : EntityBase
    {
        public AddressVO Address { get; private set; }
        //public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
