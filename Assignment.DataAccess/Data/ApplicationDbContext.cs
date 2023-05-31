using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.DataAccess.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brand { get; set; }

    public virtual DbSet<Category> Categorie { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<OrderItem> OrderItem { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Stock> Stock { get; set; }

    public virtual DbSet<Store> Store { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3MSE7TQ\\SQLEXPRESS;Initial Catalog=BikeStore;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Brand>(entity =>
    //        {
    //            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E27FECE515E");
    //        });

    //        modelBuilder.Entity<Category>(entity =>
    //        {
    //            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B473F99A09");
    //        });

    //        modelBuilder.Entity<Customer>(entity =>
    //        {
    //            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB85F1F87E52");
    //        });

    //        modelBuilder.Entity<Order>(entity =>
    //        {
    //            entity.HasKey(e => e.OrderId).HasName("PK__orders__465962294D656A95");

    //            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
    //                .OnDelete(DeleteBehavior.Cascade)
    //                .HasConstraintName("FK__orders__customer__33D4B598");

    //            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
    //                .OnDelete(DeleteBehavior.ClientSetNull)
    //                .HasConstraintName("FK__orders__staff_id__35BCFE0A");

    //            entity.HasOne(d => d.Store).WithMany(p => p.Orders).HasConstraintName("FK__orders__store_id__34C8D9D1");
    //        });

    //        modelBuilder.Entity<OrderItem>(entity =>
    //        {
    //            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D403FDCC41");

    //            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__order__398D8EEE");

    //            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__produ__3A81B327");
    //        });

    //        modelBuilder.Entity<Product>(entity =>
    //        {
    //            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5BAFADA13");

    //            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK__products__brand___286302EC");

    //            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__products__catego__276EDEB3");
    //        });

    //        modelBuilder.Entity<Staff>(entity =>
    //        {
    //            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9CFB2D7B52");

    //            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK__staffs__manager___30F848ED");

    //            entity.HasOne(d => d.Store).WithMany(p => p.Staff).HasConstraintName("FK__staffs__store_id__300424B4");
    //        });

    //        modelBuilder.Entity<Stock>(entity =>
    //        {
    //            entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D3F110020A");

    //            entity.HasOne(d => d.Product).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__product___3E52440B");

    //            entity.HasOne(d => d.Store).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__store_id__3D5E1FD2");
    //        });

    //        modelBuilder.Entity<Store>(entity =>
    //        {
    //            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30CF8441858");
    //        });

    //        OnModelCreatingPartial(modelBuilder);
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
