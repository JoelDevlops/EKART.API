using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Services.Others
{
    public interface ITokenGenerator
    {
         Task<string> GenerateJWTToken(string username,CancellationToken cancellation);
         Task<string> GenerateRefreshToken( CancellationToken cancellation);
    }
}
