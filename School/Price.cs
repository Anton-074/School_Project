using System;
using System.Collections.Generic;

namespace School;

public partial class Price
{
    public int PriceId { get; set; }

    public int DeliveryId { get; set; }

    public decimal Price1 { get; set; }

    public DateOnly DateOfStart { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;
}
