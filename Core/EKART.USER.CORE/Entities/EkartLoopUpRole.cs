using System;
using System.Collections.Generic;

namespace EKART.USER.CORE.Entities;

public partial class EkartLoopUpRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<EkartUserInRole> EkartUserInRoles { get; set; } = new List<EkartUserInRole>();
}
