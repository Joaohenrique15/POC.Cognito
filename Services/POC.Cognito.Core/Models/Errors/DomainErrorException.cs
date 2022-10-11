using System;

namespace POC.Cognito.Core.Models
{
    public class DomainErrorException : Exception
    {
        public DomainErrorException()
        {
        }

        public DomainErrorException(string message)
            : base(message)
        {
        }

        public DomainErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
