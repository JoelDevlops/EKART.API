using EKART.USER.CORE.Repositories.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Services.ValueObjects
{
    public static class StoredProcedures
    {
        public struct Authorization
        {
            public const string AuthorizeWithRoles = "usp_Ekart_Authorize_User";
        }
    }
}
