using EKART.API.DATA.Context;
using EKART.API.DATA.Repositories.Base;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.Categories
{
    public class CategoryRepository : Repository<EkartProductCategory> , ICategoryRepository
    {
        public CategoryRepository(EKartDbContext eKartDbContext) : base(eKartDbContext) { }
        public async Task<int> AddCategoryAsync(EkartProductCategory ekartProductCategory, CancellationToken cancellationToken) => await AddAsync(ekartProductCategory, cancellationToken);
        public async Task<EkartProductCategory?> FindAsync(string Name, CancellationToken cancellationToken) => await FindAsync(f => f.Name == Name, cancellationToken);
        public async Task<EkartProductCategory?> FindAsync(int Id, CancellationToken cancellationToken) => await FindAsync(f => f.Id == Id, cancellationToken);
        public async Task<int> Update(EkartProductCategory ekartProductCategory, CancellationToken cancellationToken) => await UpdateAsync(ekartProductCategory, cancellationToken);
    }
    }

