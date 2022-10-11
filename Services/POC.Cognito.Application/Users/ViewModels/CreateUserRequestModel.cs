using POC.Cognito.Domain.Users.Enums;
using System;

namespace POC.Cognito.Application.Users.ViewModels
{
    public class CreateUserRequestModel
    {
        public string Name { get; set; }
        public string CPF { get; set; } = null;
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserAddressRequestModel Address { get; set; }
        public EUserType UserType { get; set; } = EUserType.User;
    }
}
