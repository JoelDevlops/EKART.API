

using EKART.API.Models.Authorization;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EKART.API.Queries.Authorization
{
    public class ReloadRefreshTokenQuery : IRequest<TokenListItem>
    {
        [Required]
        public string RefreshToken { get; set; }
      
    }
}
