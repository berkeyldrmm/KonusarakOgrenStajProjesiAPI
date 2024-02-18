using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Context;

public partial class KonusarakOgrenStajProjesiDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public KonusarakOgrenStajProjesiDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public KonusarakOgrenStajProjesiDbContext(DbContextOptions<KonusarakOgrenStajProjesiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterEpisode> CharacterEpisodes { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:SqlServer"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Species).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<CharacterEpisode>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Character).WithMany()
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CharacterEpisodes_Characters");

            entity.HasOne(d => d.Episode).WithMany()
                .HasForeignKey(d => d.EpisodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CharacterEpisodes_Episodes");
        });

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AirDate)
                .HasMaxLength(50)
                .HasColumnName("Air_Date");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Episode1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Episode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
