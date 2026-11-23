using System;
using System.Collections.Generic;

namespace dal.Models;

public partial class Category
{
    public int CategoryCode { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Jewelry> Jewelries { get; set; } = new List<Jewelry>();
}
