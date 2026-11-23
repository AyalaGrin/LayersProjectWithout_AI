using System;
using System.Collections.Generic;

namespace dal.Models;

public partial class PurchaseItem
{
    public int ItemCode { get; set; }

    public int PurchaseCode { get; set; }

    public int JewelryCode { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Jewelry JewelryCodeNavigation { get; set; } = null!;

    public virtual Purchase PurchaseCodeNavigation { get; set; } = null!;
}
