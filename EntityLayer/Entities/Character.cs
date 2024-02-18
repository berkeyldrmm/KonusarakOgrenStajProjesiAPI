using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Status { get; set; }

    public string? Species { get; set; }

    public string? Type { get; set; }

    public string? Gender { get; set; }

    public string? Image { get; set; }

    public string? Url { get; set; }

    public DateTime? Created { get; set; }

    public string? Origin { get; set; }

    public string? Location { get; set; }
}
