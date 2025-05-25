using System;
using System.Collections.Generic;

namespace School;

public partial class AssemblyComponent
{
    public int AssemblyComponentId { get; set; }

    public int AssemblyId { get; set; }

    public int WarehouseStockId { get; set; }

    public int Quantity { get; set; }

    public virtual Assembly Assembly { get; set; } = null!;

    public virtual WarehouseStock WarehouseStock { get; set; } = null!;
}
