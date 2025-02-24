using System;
using System.Collections.Generic;

namespace taskk4.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Manager { get; set; }

    public decimal? Budget { get; set; }
}
