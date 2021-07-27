using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kahuna.MVC.Data
{
    public partial class KahunaContext : DbContext
    {
        public KahunaContext()
        {
        }

        public KahunaContext(DbContextOptions<KahunaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<SalesOrderHistory> SalesOrderHistory { get; set; }
        public virtual DbSet<SalesOrderLine> SalesOrderLine { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceHistory> ServiceHistory { get; set; }
        public virtual DbSet<ServiceOrder> ServiceOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=Kahuna; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.ZipCode).IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmpId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.HasOne(d => d.So)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Service_Order");
            });

            modelBuilder.Entity<SalesOrderHistory>(entity =>
            {
                entity.Property(e => e.HistId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SalesOrderLine>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.Soid, e.ServId });

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.SalesOrderLine)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Order_Line_Employee");

                entity.HasOne(d => d.Serv)
                    .WithMany(p => p.SalesOrderLine)
                    .HasForeignKey(d => d.ServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Order_Line_Service");

                entity.HasOne(d => d.So)
                    .WithMany(p => p.SalesOrderLine)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Order_Line_Sales_Order_History");

                entity.HasOne(d => d.SoNavigation)
                    .WithMany(p => p.SalesOrderLine)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Order_Line_Service_Order");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ServiceHistory>(entity =>
            {
                entity.Property(e => e.Shid).ValueGeneratedNever();

                entity.HasOne(d => d.So)
                    .WithMany(p => p.ServiceHistory)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_History_Service_Order");
            });

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.Property(e => e.Soid).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ServiceOrder)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Service_Order_Client");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
