using Dapper;
using EKART.API.DATA.Repositories.Base;
using EKART.USER.CORE.DTO.AuthDTO;
using EKART.USER.CORE.Repositories.Authorization;
using EKART.USER.CORE.Services.ValueObjects;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.Authorization
{
    public class AuthorizeRepository : ReadRepository<RolesDTO>, IAuthorizeRepository
    {
        public AuthorizeRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<IEnumerable<RolesDTO>> AuthorizeAsync(string Username, string Password, CancellationToken cancellation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Username", Username);
            parameters.Add("Password", Password);
            return await FindAllAsync(StoredProcedures.Authorization.AuthorizeWithRoles, parameters, cancellation);
        }
    }
}
