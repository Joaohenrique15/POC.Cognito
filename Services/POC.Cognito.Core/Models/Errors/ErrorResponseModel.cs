namespace POC.Cognito.Core.Models
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; set; }
        public string Message { get; set; }
    }
}
