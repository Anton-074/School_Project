using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Workshop
{
    public int WorkshopId { get; set; }

    public string WorkshopName { get; set; } = null!;

    public string? Location { get; set; }

    public virtual ICollection<Assemblys> Assemblies { get; set; } = new List<Assemblys>();
}
