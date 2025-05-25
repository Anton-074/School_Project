using System;
using System.Collections.Generic;

namespace School.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string DirectorFullName { get; set; } = null!;

    public string LegalAddress { get; set; } = null!;

    public short? TypeSupplierId { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual TypeSupplier? TypeSupplier { get; set; }
}
