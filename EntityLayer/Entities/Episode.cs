using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public partial class Episode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? AirDate { get; set; }

    public string Episode1 { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime? Created { get; set; }
}
