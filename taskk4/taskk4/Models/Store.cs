using System;
using System.Collections.Generic;

namespace taskk4.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }
}
