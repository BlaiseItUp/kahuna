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
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Kahuna;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("Address(...)")
                    .HasMaxLength(50);

                entity.Property(e => e.Cfname)
                    .IsRequired()
                    .HasColumnName("CFName")
                    .HasMaxLength(50);

                entity.Property(e => e.Clname)
                    .IsRequired()
                    .HasColumnName("CLName")
                    .HasMaxLength(50);

                entity.Property(e => e.CriminalRecord).HasMaxLength(50);

                entity.Property(e => e.Military).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Efname)
                    .IsRequired()
                    .HasColumnName("EFName")
                    .HasMaxLength(50);

                entity.Property(e => e.Elname)
                    .IsRequired()
                    .HasColumnName("ELName")
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId)
                    .HasColumnName("PaymentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Soid).HasColumnName("SOID");

                entity.HasOne(d => d.So)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Service_Order");
            });

            modelBuilder.Entity<SalesOrderHistory>(entity =>
            {
                entity.HasKey(e => e.HistId);

                entity.ToTable("Sales_Order_History");

                entity.Property(e => e.HistId)
                    .HasColumnName("HistID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Soid).HasColumnName("SOID");

                entity.HasOne(d => d.So)
                    .WithMany(p => p.SalesOrderHistory)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Order_History_Service_Order");
            });

            modelBuilder.Entity<SalesOrderLine>(entity =>
            {
                entity.HasKey(e => new { e.EmpId, e.Soid, e.ServId });

                entity.ToTable("Sales_Order_Line");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Soid).HasColumnName("SOID");

                entity.Property(e => e.ServId).HasColumnName("ServID");

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
                    .HasConstraintName("FK_Sales_Order_Line_Service_Order");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServId);

                entity.Property(e => e.ServId)
                    .HasColumnName("ServID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ServName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServiceHistory>(entity =>
            {
                entity.HasKey(e => e.Shid);

                entity.ToTable("Service_History");

                entity.Property(e => e.Shid)
                    .HasColumnName("SHID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Soid).HasColumnName("SOID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.So)
                    .WithMany(p => p.ServiceHistory)
                    .HasForeignKey(d => d.Soid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_History_Service_Order");
            });

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => e.Soid);

                entity.ToTable("Service_Order");

                entity.Property(e => e.Soid)
                    .HasColumnName("SOID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateCaseClosed).HasColumnType("datetime");

                entity.Property(e => e.DateCaseOpened).HasColumnType("datetime");

                entity.Property(e => e.DatePlaced).HasColumnType("datetime");

                entity.Property(e => e.Decline).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Override).HasMaxLength(50);

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
