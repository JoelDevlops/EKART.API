using Dapper;
using EKART.API.DATA.Repositories.Base;
using EKART.USER.CORE.DTO.AuthDTO;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Authorization;
using EKART.USER.CORE.Repositories.Categories;
using EKART.USER.CORE.Services.ValueObjects;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.Categories
{
    public class CategoryReadRepository : ReadRepository<EkartProductCategory>, ICategoriesReadRepository
    {
        public CategoryReadRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<IEnumerable<EkartProductCategory>> GetAll(bool IsActive, CancellationToken cancellation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("IsActive", IsActive);
            return await FindAllAsync(StoredProcedures.Categories.GetAllCategory, parameters, cancellation);
        }

     
    }
}

