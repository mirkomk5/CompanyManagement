using System;
using System.Collections.Generic;

namespace BE_CompanyTest.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly? RegistrationDate { get; set; }

    public string? Address { get; set; }

    public int? AdminLevel { get; set; }

    public virtual ICollection<Credential> Credentials { get; set; } = new List<Credential>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
