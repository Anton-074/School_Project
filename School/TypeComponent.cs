using System;
using System.Collections.Generic;

namespace School;

public partial class TypeComponent
{
    public short TypeComponentId { get; set; }

    public string TypeComponentName { get; set; } = null!;

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();
}
