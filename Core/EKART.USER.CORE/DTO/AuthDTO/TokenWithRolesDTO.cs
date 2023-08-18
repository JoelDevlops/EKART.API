using EKART.USER.CORE.DTO.BaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.DTO.AuthDTO
{
    public class TokenWithRolesDTO 
    {
        public  string JwtToken { get; set; }    
        public string RefreshToken { get; set; }

        public string[] Roles { get; set; }
    }
}
