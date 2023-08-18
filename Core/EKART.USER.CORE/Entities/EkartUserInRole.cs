using System;
using System.Collections.Generic;

namespace EKART.USER.CORE.Entities;

public partial class EkartUserInRole
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }
}
