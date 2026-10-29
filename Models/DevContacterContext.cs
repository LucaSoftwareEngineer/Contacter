using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contacter.Models;

public partial class DevContacterContext : DbContext
{
    public DevContacterContext()
    {
    }

    public DevContacterContext(DbContextOptions<DevContacterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contatti> Contattis { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;database=DEV_CONTACTER;user=sa;password=admin;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contatti>(entity =>
        {
            entity.HasKey(e => e.ConId);

            entity.ToTable("contatti");

            entity.Property(e => e.ConId).HasColumnName("con_id");
            entity.Property(e => e.ConEmail)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("con_email");
            entity.Property(e => e.ConNome)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("con_nome");
            entity.Property(e => e.ConTel)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("con_tel");
            entity.Property(e => e.ConUteId).HasColumnName("con_ute_id");

            entity.HasOne(d => d.ConUte).WithMany(p => p.Contattis)
                .HasForeignKey(d => d.ConUteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contatti_utenti");
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.UteId);

            entity.ToTable("utenti");

            entity.Property(e => e.UteId).HasColumnName("ute_id");
            entity.Property(e => e.UteEmail)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ute_email");
            entity.Property(e => e.UtePass)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ute_pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
