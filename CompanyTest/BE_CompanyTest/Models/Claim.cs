using System;
using System.Collections.Generic;

namespace BE_CompanyTest.Models;

public partial class Claim
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;
}
