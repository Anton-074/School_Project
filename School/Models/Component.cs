using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Component
{
    public int ComponentId { get; set; }

    public string ComponentName { get; set; } = null!;

    public string? ComponentDescription { get; set; }

    public DateOnly ManufactureDate { get; set; }

    public short TypeComponentId { get; set; }

    public short CompanyComponentId { get; set; }

    public virtual CompanyComponent CompanyComponent { get; set; } = null!;

    public virtual TypeComponent TypeComponent { get; set; } = null!;

    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = new List<WarehouseStock>();
}
