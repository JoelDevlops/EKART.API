using System;
using System.Collections.Generic;

namespace EKART.USER.CORE.Entities;

public  class EkartUserDetail
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool IsActive { get; set; }
}
