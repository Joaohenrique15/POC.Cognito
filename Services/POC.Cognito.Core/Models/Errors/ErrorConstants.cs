using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Cognito.Core.Models.Errors
{
    public static class ErrorConstants
    {
        public const string WRONG_PASSWORD = "WRONG_PASSWORD";
        public const string USER_ALREADY_EXISTS = "USER_ALREADY_EXISTS";
        public const string SHOULD_BE_FIRST_PASSWORD_CHANGE = "SHOULD_BE_FIRST_PASSWORD_CHANGE";
        public const string NEW_PASSWORD_REQUIRED = "NEW_PASSWORD_REQUIRED";
        public const string USER_NOT_FOUND = "USER_NOT_FOUND";
        public const string TOKEN_EXPIRED = "TOKEN_EXPIRED";
        public const string WRONG_TOKEN = "WRONG_TOKEN";
        public const string USER_SHOULD_HAVE_LAST_NAME = "USER_SHOULD_HAVE_LAST_NAME";
    }
}
