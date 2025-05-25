using System;
using System.Collections.Generic;

namespace School;

public partial class WarehouseStock
{
    public int StockId { get; set; }

    public int WarehouseId { get; set; }

    public int ComponentId { get; set; }

    public int Quantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual ICollection<AssemblyComponent> AssemblyComponents { get; set; } = new List<AssemblyComponent>();

    public virtual Component Component { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
