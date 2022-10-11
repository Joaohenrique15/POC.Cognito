namespace POC.Cognito.Application.Users.ViewModels
{
    public class UserAddressRequestModel
    {
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
