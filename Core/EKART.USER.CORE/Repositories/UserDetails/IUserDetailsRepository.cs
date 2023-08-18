using EKART.USER.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Repositories.UserDetails
{
    public interface IUserDetailsRepository : IDisposable
    {
        Task<EkartUserDetail> GetByEmail(string email, CancellationToken cancellationToken);
        Task<EkartUserDetail> GetById(int Id, CancellationToken cancellationToken);
        Task <IEnumerable<EkartUserDetail>> GetAll(bool IsActive, CancellationToken cancellationToken);

    }
}
