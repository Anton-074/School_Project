using System;
using System.Collections.Generic;

namespace School;

public partial class SchoolRole
{
    public int SchoolRoleId { get; set; }

    public int SchoolId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual School School { get; set; } = null!;
}
