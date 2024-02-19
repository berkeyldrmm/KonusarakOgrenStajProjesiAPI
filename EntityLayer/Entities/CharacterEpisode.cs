using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public partial class CharacterEpisode
{
    public int Id { get; set; }
    public int EpisodeId { get; set; }

    public int CharacterId { get; set; }

    public virtual Character Character { get; set; } = null!;

    public virtual Episode Episode { get; set; } = null!;
}
