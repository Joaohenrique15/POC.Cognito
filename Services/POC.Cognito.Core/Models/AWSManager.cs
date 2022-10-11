namespace POC.Cognito.Core.Models
{
    public class AWSManager
    {
        public string Region { get; set; }
        public string AcessKey { get; set; }
        public string SecretKey { get; set; }
        public string CognitoId { get; set; }
        public string CognitoPoolId { get; set; }
        public string CognitoPoolARN { get; set; }
    }
}
