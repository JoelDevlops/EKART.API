using EKART.API.DATA.Context;
using EKART.API.DATA.Repositories.Base;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Token;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.Token
{
    public class TokenDetailsRepository : Repository<EkartTokenDetails>, ITokenDetailsRepository
    {
        public TokenDetailsRepository(EKartDbContext eKartDbContext, IConfiguration configuration) : base(eKartDbContext)
        {

        }
        public async Task<EkartTokenDetails> FindAsync(int userId, CancellationToken cancellationToken) => await FindAsync(f => f.UserId == userId, cancellationToken);

        public async Task<EkartTokenDetails> FindWithRefreshToken(string refreshToken, CancellationToken cancellationToken) => await FindAsync(f => f.RefreshToken == refreshToken, cancellationToken);

        public async Task<bool> IsExists(int userId, CancellationToken cancellationToken) => await IsExistAsync(f => f.UserId == userId, cancellationToken);
        public async Task<int> SaveToken(EkartTokenDetails tokenDetails, CancellationToken cancellationToken) => await AddAsync(tokenDetails, cancellationToken);
        public async Task<int> Update(EkartTokenDetails tokenDetails, CancellationToken cancellationToken) => await UpdateAsync(tokenDetails, cancellationToken);   
        
    }
}
