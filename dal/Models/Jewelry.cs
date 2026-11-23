using System;
using System.Collections.Generic;

namespace dal.Models;

public partial class Jewelry
{
    public int JewelryCode { get; set; }

    public string JewelryName { get; set; } = null!;

    public int CategoryCode { get; set; }

    public int MaterialCode { get; set; }

    public decimal Price { get; set; }

    public decimal DiscountPercent { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Category CategoryCodeNavigation { get; set; } = null!;

    public virtual Material MaterialCodeNavigation { get; set; } = null!;

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}
