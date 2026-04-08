using System;
using System.Collections.Generic;

namespace BE_CompanyTest.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
