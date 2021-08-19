using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CyberpunkAPI.Models
{
    public partial class cyberpunkContext : DbContext
    {
        public cyberpunkContext()
        {
        }

        public cyberpunkContext(DbContextOptions<cyberpunkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<SpecialAbilities> SpecialAbilities { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=cyberpunk;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SpecialAbilities>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("Special_Abilities");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlayerID");

                entity.Property(e => e.CharismaticLeadership).HasColumnName("Charismatic_Leadership");

                entity.Property(e => e.CombatSense).HasColumnName("Combat_Sense");

                entity.Property(e => e.JuryRig).HasColumnName("Jury_Rig");

                entity.Property(e => e.MedicalTech).HasColumnName("Medical_Tech");

                //This was causing a circular reference
               /* entity.HasOne(d => d.Player)
                    .WithOne(p => p.SpecialAbilities)
                    .HasForeignKey<SpecialAbilities>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Special_Abilities"); */
            });

            modelBuilder.Entity<Stats>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK_Stats_1");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlayerID");

                entity.Property(e => e.Attr).HasColumnName("ATTR");

                entity.Property(e => e.Body).HasColumnName("BODY");

                entity.Property(e => e.Cool).HasColumnName("COOL");

                entity.Property(e => e.Emp).HasColumnName("EMP");

                entity.Property(e => e.Int).HasColumnName("INT");

                entity.Property(e => e.Luck).HasColumnName("LUCK");

                entity.Property(e => e.Ma).HasColumnName("MA");

                entity.Property(e => e.Ref).HasColumnName("REF");

                entity.Property(e => e.Tech).HasColumnName("TECH");

                //This was causing a circular reference
                /*entity.HasOne(d => d.Player)
                    .WithOne(p => p.Stats)
                    .HasForeignKey<Stats>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stats_Player"); */
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
