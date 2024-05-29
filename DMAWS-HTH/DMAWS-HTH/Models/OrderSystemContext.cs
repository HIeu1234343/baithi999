using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_HTH.Models;

public partial class OrderSystemContext : DbContext
{
    public OrderSystemContext()
    {
    }

    public OrderSystemContext(DbContextOptions<OrderSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VEE3AUC\\SQLEXPRESS;Initial Catalog=OrderSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.ItemCode).HasName("PK__Orders__3ECC0FEB89536169");

            entity.Property(e => e.ItemCode).ValueGeneratedNever();
            entity.Property(e => e.ItemName).HasMaxLength(100);
            entity.Property(e => e.OrderAddress).HasMaxLength(255);
            entity.Property(e => e.OrderDelivery).HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
