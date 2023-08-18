using EKART.API.Models.UserDetail;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EKART.API.Queries.UserDetail
{
    public class GetAllUserDetailQuery : IRequest<IEnumerable<UserDetailListItem>>
    {
        [Required]
        public bool IsActive { get; set; }

    }
}

