using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppCRUD.Entities;

public partial class WebCrudContext : DbContext
{
    public WebCrudContext()
    {
    }

    public WebCrudContext(DbContextOptions<WebCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DITISJL\\MYSQL;Database=WebCRUD;User Id=sa;Password=hongphat@3008;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.ToTable("Khoa");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.ToTable("Lop");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.KhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.Khoa)
                .HasConstraintName("FK_l");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.ToTable("Sinhvien");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.KhoaNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Khoa)
                .HasConstraintName("FK_k");

            entity.HasOne(d => d.LopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Lop)
                .HasConstraintName("FK_HS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
