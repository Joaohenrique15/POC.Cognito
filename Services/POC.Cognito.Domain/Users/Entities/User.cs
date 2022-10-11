using POC.Cognito.Core.Entities;
using POC.Cognito.Core.Models;
using POC.Cognito.Core.Models.Errors;
using POC.Cognito.Core.Models.ValueObjects;
using POC.Cognito.Domain.Users.Enums;
using System;
using System.Collections.Generic;

namespace POC.Cognito.Domain.Users.Entities
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public bool WasAcceptedTerms { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Guid CognitoUserId { get; private set; }
        public EUserType UserType { get; set; }
        public AddressVO Address { get; private set; }

        //TODO PENSAR EM RELAÇÃO - public UserAddress UserAddress { get; set; }

        internal User() { }

        public User(string name, string cpf, string phoneNumber, string gender, string email,
            DateTime birthDate, EUserType userType, AddressVO address)
        {
            SetUserName(name);
            CPF = cpf;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;
            UserType = userType;
            Address = address;
        }

        public void SetUserName(string name)
        {
            if (name.Split(' ').Length <= 1)
                throw new DomainErrorException(ErrorConstants.USER_SHOULD_HAVE_LAST_NAME);
            this.Name = name;
        }

        public void SetCognitoUserId(Guid cognitoUserId)
        {
            CognitoUserId = cognitoUserId;
        }
    }
}
