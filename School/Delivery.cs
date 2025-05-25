using System;
using System.Collections.Generic;

namespace School;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public int SupplierId { get; set; }

    public int AssemblyId { get; set; }

    public int SchoolId { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public virtual Assembly Assembly { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual School School { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
