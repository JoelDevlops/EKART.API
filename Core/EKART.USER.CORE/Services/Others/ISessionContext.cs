using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Services.Others
{
    public interface ISessionContext
    {
        Task<string> GetCurrentUser( CancellationToken cancellation);
    }
}
