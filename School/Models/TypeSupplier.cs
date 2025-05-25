using System;
using System.Collections.Generic;

namespace School.Models;

public partial class TypeSupplier
{
    public short TypeSupplierId { get; set; }

    public string TypeSupplierName { get; set; } = null!;

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
