namespace fahlen_dev_webapi.Contracts.Response
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        
        public string RefreshToken { get; set; }
    }
}