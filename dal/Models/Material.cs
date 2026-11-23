using System;
using System.Collections.Generic;

namespace dal.Models;

public partial class Material
{
    public int MaterialCode { get; set; }

    public string MaterialName { get; set; } = null!;

    public virtual ICollection<Jewelry> Jewelries { get; set; } = new List<Jewelry>();
}
