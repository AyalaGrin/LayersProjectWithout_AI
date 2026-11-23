using System;
using System.Collections.Generic;

namespace dal.Models;

public partial class Customer
{
    public int CustomerCode { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? HouseNumber { get; set; }

    public string? ZipCode { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
