using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Entities
{
    public class EkartTokenDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime JWTExpiry { get; set; }
        public DateTime RefreshExpiry { get; set; }

    }
}
