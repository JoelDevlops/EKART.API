using EKART.API.DATA.Context;
using EKART.API.DATA.Repositories.Base;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Token;
using EKART.USER.CORE.Repositories.UserDetails;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.User
{
    public class UserDetailsRepository : Repository<EkartUserDetail>, IUserDetailsRepository
    {
        public UserDetailsRepository(EKartDbContext eKartDbContext) : base(eKartDbContext){  }

        public async Task<IEnumerable<EkartUserDetail>> GetAll(bool IsActive, CancellationToken cancellationToken) =>
            await FindAllAsync(f => f.IsActive == IsActive, cancellationToken);

        public async Task<EkartUserDetail> GetByEmail(string email, CancellationToken cancellationToken) => 
            await FindAsync(f => f.Email == email, cancellationToken);

        public async Task<EkartUserDetail> GetById(int Id, CancellationToken cancellationToken) =>
            await FindAsync(f => f.Id == Id, cancellationToken);
    }
}
