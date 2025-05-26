using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Assemblys> Assemblies { get; set; } = new List<Assemblys>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
