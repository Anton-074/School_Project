using System;
using System.Collections.Generic;

namespace School;

public partial class CompanyComponent
{
    public short CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();
}
