using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BE_CompanyTest.Models;

public partial class CompanyTestContext : DbContext
{
    public CompanyTestContext()
    {
    }

    public CompanyTestContext(DbContextOptions<CompanyTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KIS3A7Q\\SQLEXPRESS;Database=CompanyTest;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Message).HasMaxLength(500);

            entity.HasOne(d => d.Order).WithMany(p => p.Claims)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claims_Products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Notes).HasMaxLength(200);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Discount).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(250);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.AdminLevel).HasDefaultValue(0);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
