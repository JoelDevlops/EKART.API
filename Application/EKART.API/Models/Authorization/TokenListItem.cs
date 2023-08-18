namespace EKART.API.Models.Authorization
{
    public class TokenListItem
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
