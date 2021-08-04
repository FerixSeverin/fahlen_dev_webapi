namespace fahlen_dev_webapi.Contracts.Requests
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        
        public string RefreshToken { get; set; }
    }
}