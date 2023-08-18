using EKART.USER.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Repositories.Token
{
    public interface ITokenDetailsRepository : IDisposable
    {
        Task<int> SaveToken(EkartTokenDetails tokenDetails, CancellationToken cancellationToken);
        Task<bool> IsExists(int userId, CancellationToken cancellationToken);
        Task<int> Update(EkartTokenDetails tokenDetails, CancellationToken cancellationToken);
        Task <EkartTokenDetails> FindAsync(int userId, CancellationToken cancellationToken);
        Task<EkartTokenDetails> FindWithRefreshToken(string refreshToken, CancellationToken cancellationToken);

    }
}
