using System;
using System.Collections.Generic;

namespace School;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<SchoolRole> SchoolRoles { get; set; } = new List<SchoolRole>();
}
