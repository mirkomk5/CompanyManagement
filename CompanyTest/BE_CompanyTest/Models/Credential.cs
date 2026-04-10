using System;
using System.Collections.Generic;

namespace BE_CompanyTest.Models;

public partial class Credential
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Value { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
