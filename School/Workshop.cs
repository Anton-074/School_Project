using System;
using System.Collections.Generic;

namespace School;

public partial class Workshop
{
    public int WorkshopId { get; set; }

    public string WorkshopName { get; set; } = null!;

    public string? Location { get; set; }

    public virtual ICollection<Assembly> Assemblies { get; set; } = new List<Assembly>();
}
