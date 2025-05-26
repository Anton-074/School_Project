using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Assemblys
{
    public int AssemblyId { get; set; }

    public int WorkshopId { get; set; }

    public DateOnly AssemblyDate { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<AssemblyComponent> AssemblyComponents { get; set; } = new List<AssemblyComponent>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Status? Status { get; set; }

    public virtual Workshop Workshop { get; set; } = null!;
}
