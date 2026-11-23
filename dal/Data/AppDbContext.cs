using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dal.Models;

namespace dal.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Jewelry> Jewelries { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK__categori__BC9D1E7DF8B4BDD6");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "UQ__categori__5189E25535D84CA4").IsUnique();

            entity.Property(e => e.CategoryCode)
                .ValueGeneratedNever()
                .HasColumnName("category_code");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerCode).HasName("PK__customer__6A9E4CB64DC97FD0");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerCode)
                .ValueGeneratedNever()
                .HasColumnName("customer_code");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.City)
                .HasMaxLength(60)
                .HasColumnName("city");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(10)
                .HasColumnName("house_number");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Jewelry>(entity =>
        {
            entity.HasKey(e => e.JewelryCode).HasName("PK__jewelry__5DF619FA45A7C4FE");

            entity.ToTable("jewelry");

            entity.Property(e => e.JewelryCode)
                .ValueGeneratedNever()
                .HasColumnName("jewelry_code");
            entity.Property(e => e.CategoryCode).HasColumnName("category_code");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount_percent");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .HasColumnName("image_url");
            entity.Property(e => e.JewelryName)
                .HasMaxLength(100)
                .HasColumnName("jewelry_name");
            entity.Property(e => e.MaterialCode).HasColumnName("material_code");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.Jewelries)
                .HasForeignKey(d => d.CategoryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_jewelry_category");

            entity.HasOne(d => d.MaterialCodeNavigation).WithMany(p => p.Jewelries)
                .HasForeignKey(d => d.MaterialCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_jewelry_material");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialCode).HasName("PK__material__047B7CDA6EB6A1FF");

            entity.ToTable("materials");

            entity.HasIndex(e => e.MaterialName, "UQ__material__13567534D1EF2BD5").IsUnique();

            entity.Property(e => e.MaterialCode)
                .ValueGeneratedNever()
                .HasColumnName("material_code");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(50)
                .HasColumnName("material_name");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseCode).HasName("PK__purchase__E95D8F8B8941D57B");

            entity.ToTable("purchases");

            entity.Property(e => e.PurchaseCode)
                .ValueGeneratedNever()
                .HasColumnName("purchase_code");
            entity.Property(e => e.CustomerCode).HasColumnName("customer_code");
            entity.Property(e => e.FinalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("final_amount");
            entity.Property(e => e.PaymentLast4)
                .HasMaxLength(4)
                .HasColumnName("payment_last4");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .HasColumnName("payment_method");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(200)
                .HasColumnName("shipping_address");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .HasColumnName("shipping_method");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_purchases_customer");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => e.ItemCode).HasName("PK__purchase__4A67201FB6C273D8");

            entity.ToTable("purchase_items");

            entity.Property(e => e.ItemCode)
                .ValueGeneratedNever()
                .HasColumnName("item_code");
            entity.Property(e => e.JewelryCode).HasColumnName("jewelry_code");
            entity.Property(e => e.PurchaseCode).HasColumnName("purchase_code");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.JewelryCodeNavigation).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.JewelryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_items_jewelry");

            entity.HasOne(d => d.PurchaseCodeNavigation).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseCode)
                .HasConstraintName("FK_items_purchase");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
