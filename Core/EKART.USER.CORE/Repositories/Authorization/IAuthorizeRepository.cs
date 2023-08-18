using EKART.USER.CORE.DTO.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Repositories.Authorization
{
    public interface IAuthorizeRepository : IDisposable
    {
        Task<IEnumerable<RolesDTO>> AuthorizeAsync(string Username,string Password, CancellationToken cancellation);
    }
}
