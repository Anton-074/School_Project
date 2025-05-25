using System;
using System.Collections.Generic;

namespace School;

public partial class Assembly
{
    public int AssemblyId { get; set; }

    public int WorkshopId { get; set; }

    public DateOnly AssemblyDate { get; set; }

    public virtual ICollection<AssemblyComponent> AssemblyComponents { get; set; } = new List<AssemblyComponent>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Workshop Workshop { get; set; } = null!;
}
