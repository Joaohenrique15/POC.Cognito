namespace POC.Cognito.Application.Users.ViewModels
{
    public class FirstPasswordChangeRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
