using EKART.USER.CORE.DTO.AuthDTO;

namespace EKART.API.Models.Authorization
{
    public class TokenWithRolesListItem
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public string[] Roles { get; set; }
    }
}
