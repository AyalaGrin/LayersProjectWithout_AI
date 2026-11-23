using System;
using System.Collections.Generic;

namespace dal.Models;

public partial class Purchase
{
    public int PurchaseCode { get; set; }

    public int CustomerCode { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public decimal FinalAmount { get; set; }

    public string? ShippingMethod { get; set; }

    public string? ShippingAddress { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentLast4 { get; set; }

    public virtual Customer CustomerCodeNavigation { get; set; } = null!;

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}
