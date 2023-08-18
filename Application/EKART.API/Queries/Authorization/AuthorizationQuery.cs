using EKART.API.Models.Authorization;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EKART.API.Queries.Authorization
{
    public class AuthorizationQuery : IRequest<TokenWithRolesListItem>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
