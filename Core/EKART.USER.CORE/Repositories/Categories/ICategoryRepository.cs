using EKART.USER.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Repositories.Categories
{
    public interface ICategoryRepository : IDisposable
    {
        Task<int> AddCategoryAsync(EkartProductCategory ekartProductCategory, CancellationToken cancellation);
        Task<int> Update(EkartProductCategory ekartProductCategory, CancellationToken cancellation);
        Task<EkartProductCategory> FindAsync(string Name, CancellationToken cancellationToken);
        Task<EkartProductCategory> FindAsync(int Id, CancellationToken cancellationToken);


    }
}
