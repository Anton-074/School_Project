using System;
using System.Collections.Generic;

namespace School.Models;

public partial class UserSchool
{
    public int UserSchoolId { get; set; }

    public int UsersId { get; set; }

    public int SchoolId { get; set; }

    public virtual Schools School { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
