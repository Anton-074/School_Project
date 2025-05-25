using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School;

public partial class SchollContext : DbContext
{
    public SchollContext()
    {
    }

    public SchollContext(DbContextOptions<SchollContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assembly> Assemblies { get; set; }

    public virtual DbSet<AssemblyComponent> AssemblyComponents { get; set; }

    public virtual DbSet<CompanyComponent> CompanyComponents { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<SchoolRole> SchoolRoles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TypeComponent> TypeComponents { get; set; }

    public virtual DbSet<TypeSupplier> TypeSuppliers { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseStock> WarehouseStocks { get; set; }

    public virtual DbSet<Workshop> Workshops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=scholl;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assembly>(entity =>
        {
            entity.HasKey(e => e.AssemblyId).HasName("assemblies_pkey");

            entity.ToTable("assemblies");

            entity.Property(e => e.AssemblyId).HasColumnName("assembly_id");
            entity.Property(e => e.AssemblyDate).HasColumnName("assembly_date");
            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");

            entity.HasOne(d => d.Workshop).WithMany(p => p.Assemblies)
                .HasForeignKey(d => d.WorkshopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assemblies_workshop_id_fkey");
        });

        modelBuilder.Entity<AssemblyComponent>(entity =>
        {
            entity.HasKey(e => e.AssemblyComponentId).HasName("assembly_components_pkey");

            entity.ToTable("assembly_components");

            entity.HasIndex(e => e.AssemblyId, "idx_assembly_components_assembly");

            entity.Property(e => e.AssemblyComponentId).HasColumnName("assembly_component_id");
            entity.Property(e => e.AssemblyId).HasColumnName("assembly_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.WarehouseStockId).HasColumnName("warehouse_stock_id");

            entity.HasOne(d => d.Assembly).WithMany(p => p.AssemblyComponents)
                .HasForeignKey(d => d.AssemblyId)
                .HasConstraintName("assembly_components_assembly_id_fkey");

            entity.HasOne(d => d.WarehouseStock).WithMany(p => p.AssemblyComponents)
                .HasForeignKey(d => d.WarehouseStockId)
                .HasConstraintName("assembly_components_warehouse_stock_id");
        });

        modelBuilder.Entity<CompanyComponent>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("company_component_pkey");

            entity.ToTable("company_component");

            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyName).HasColumnName("company_name");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.ComponentId).HasName("components_pkey");

            entity.ToTable("components");

            entity.Property(e => e.ComponentId).HasColumnName("component_id");
            entity.Property(e => e.CompanyComponentId).HasColumnName("company_component_id");
            entity.Property(e => e.ComponentDescription).HasColumnName("component_description");
            entity.Property(e => e.ComponentName)
                .HasMaxLength(100)
                .HasColumnName("component_name");
            entity.Property(e => e.ManufactureDate).HasColumnName("manufacture_date");
            entity.Property(e => e.TypeComponentId).HasColumnName("type_component_id");

            entity.HasOne(d => d.CompanyComponent).WithMany(p => p.Components)
                .HasForeignKey(d => d.CompanyComponentId)
                .HasConstraintName("fk_company_component_id_to_components");

            entity.HasOne(d => d.TypeComponent).WithMany(p => p.Components)
                .HasForeignKey(d => d.TypeComponentId)
                .HasConstraintName("fk_type_component_id_to_components");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("deliveries_pkey");

            entity.ToTable("deliveries");

            entity.HasIndex(e => e.SchoolId, "idx_deliveries_school");

            entity.HasIndex(e => e.SupplierId, "idx_deliveries_supplier");

            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.AssemblyId).HasColumnName("assembly_id");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Assembly).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.AssemblyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveries_assembly_id_fkey");

            entity.HasOne(d => d.School).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveries_school_id_fkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveries_supplier_id_fkey");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("price_pkey");

            entity.ToTable("price");

            entity.Property(e => e.PriceId)
                .ValueGeneratedNever()
                .HasColumnName("price_id");
            entity.Property(e => e.DateOfStart).HasColumnName("date_of_start");
            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.Price1)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Prices)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK_delivery_id_to_price");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("schools_pkey");

            entity.ToTable("schools");

            entity.Property(e => e.SchoolId).HasColumnName("school_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.SchoolName)
                .HasMaxLength(200)
                .HasColumnName("school_name");
        });

        modelBuilder.Entity<SchoolRole>(entity =>
        {
            entity.HasKey(e => e.SchoolRoleId).HasName("school_roles_pkey");

            entity.ToTable("school_roles");

            entity.HasIndex(e => new { e.SchoolId, e.RoleId }, "school_roles_school_id_role_id_key").IsUnique();

            entity.Property(e => e.SchoolRoleId).HasColumnName("school_role_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");

            entity.HasOne(d => d.Role).WithMany(p => p.SchoolRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("school_roles_role_id_fkey");

            entity.HasOne(d => d.School).WithMany(p => p.SchoolRoles)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("school_roles_school_id_fkey");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.DirectorFullName).HasColumnName("director_full_name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.LegalAddress).HasColumnName("legal_address");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplier_name");
            entity.Property(e => e.TypeSupplierId).HasColumnName("type_supplier_id");

            entity.HasOne(d => d.TypeSupplier).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.TypeSupplierId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_type_supplier_id_to_suppliers");
        });

        modelBuilder.Entity<TypeComponent>(entity =>
        {
            entity.HasKey(e => e.TypeComponentId).HasName("type_component_pkey");

            entity.ToTable("type_component");

            entity.Property(e => e.TypeComponentId).HasColumnName("type_component_id");
            entity.Property(e => e.TypeComponentName).HasColumnName("type_component_name");
        });

        modelBuilder.Entity<TypeSupplier>(entity =>
        {
            entity.HasKey(e => e.TypeSupplierId).HasName("type_suppliers_pkey");

            entity.ToTable("type_suppliers");

            entity.Property(e => e.TypeSupplierId).HasColumnName("type_supplier_id");
            entity.Property(e => e.TypeSupplierName).HasColumnName("type_supplier_name");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("warehouses_pkey");

            entity.ToTable("warehouses");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(100)
                .HasColumnName("warehouse_name");
        });

        modelBuilder.Entity<WarehouseStock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("warehouse_stock_pkey");

            entity.ToTable("warehouse_stock");

            entity.HasIndex(e => e.ComponentId, "idx_warehouse_stock_component");

            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.ComponentId).HasColumnName("component_id");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_updated");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

            entity.HasOne(d => d.Component).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.ComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("warehouse_stock_component_id_fkey");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("warehouse_stock_warehouse_id_fkey");
        });

        modelBuilder.Entity<Workshop>(entity =>
        {
            entity.HasKey(e => e.WorkshopId).HasName("workshops_pkey");

            entity.ToTable("workshops");

            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.WorkshopName)
                .HasMaxLength(100)
                .HasColumnName("workshop_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
