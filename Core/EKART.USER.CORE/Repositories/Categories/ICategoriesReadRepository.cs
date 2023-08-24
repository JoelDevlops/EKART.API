using EKART.USER.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Repositories.Categories
{
    public interface ICategoriesReadRepository : IDisposable
    {
        Task<IEnumerable<EkartProductCategory>> GetAll(bool IsActive, CancellationToken cancellationToken);
    }
}
