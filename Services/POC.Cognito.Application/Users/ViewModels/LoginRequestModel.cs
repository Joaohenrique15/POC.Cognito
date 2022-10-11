namespace POC.Cognito.Application.Users.ViewModels
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ELoginFlow LoginFlow { get; set; }
        public string RefreshToken { get; set; }
    }
}
