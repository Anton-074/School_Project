using System;
using System.Collections.Generic;

namespace School;

public partial class School
{
    public int SchoolId { get; set; }

    public string SchoolName { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<SchoolRole> SchoolRoles { get; set; } = new List<SchoolRole>();
}
