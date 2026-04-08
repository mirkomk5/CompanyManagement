using System;
using System.Collections.Generic;

namespace BE_CompanyTest.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ProductId { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();

    public virtual User Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
