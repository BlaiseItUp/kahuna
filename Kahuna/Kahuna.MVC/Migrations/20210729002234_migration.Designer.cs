﻿// <auto-generated />
using System;
using Kahuna.MVC.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kahuna.MVC.Migrations
{
    [DbContext(typeof(KahunaContext))]
    [Migration("20210729002234_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kahuna.MVC.data.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnName("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("Address(...)")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Cfname")
                        .IsRequired()
                        .HasColumnName("CFName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Clname")
                        .IsRequired()
                        .HasColumnName("CLName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CriminalRecord")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Military")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true)
                        .HasMaxLength(5);

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Kahuna.MVC.data.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnName("EmpID")
                        .HasColumnType("int");

                    b.Property<string>("Efname")
                        .IsRequired()
                        .HasColumnName("EFName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Elname")
                        .IsRequired()
                        .HasColumnName("ELName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Kahuna.MVC.data.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnName("PaymentID")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnName("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("Soid")
                        .HasColumnName("SOID")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("Soid");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Kahuna.MVC.data.SalesOrderHistory", b =>
                {
                    b.Property<int>("HistId")
                        .HasColumnName("HistID")
                        .HasColumnType("int");

                    b.Property<int>("EmpId")
                        .HasColumnName("EmpID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Soid")
                        .HasColumnName("SOID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HistId");

                    b.HasIndex("Soid");

                    b.ToTable("Sales_Order_History");
                });

            modelBuilder.Entity("Kahuna.MVC.data.SalesOrderLine", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnName("EmpID")
                        .HasColumnType("int");

                    b.Property<int>("Soid")
                        .HasColumnName("SOID")
                        .HasColumnType("int");

                    b.Property<int>("ServId")
                        .HasColumnName("ServID")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("EmpId", "Soid", "ServId");

                    b.HasIndex("ServId");

                    b.HasIndex("Soid");

                    b.ToTable("Sales_Order_Line");
                });

            modelBuilder.Entity("Kahuna.MVC.data.Service", b =>
                {
                    b.Property<int>("ServId")
                        .HasColumnName("ServID")
                        .HasColumnType("int");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ServName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ServId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Kahuna.MVC.data.ServiceHistory", b =>
                {
                    b.Property<int>("Shid")
                        .HasColumnName("SHID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ModifyingUser")
                        .HasColumnType("int");

                    b.Property<int>("Soid")
                        .HasColumnName("SOID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Shid");

                    b.HasIndex("Soid");

                    b.ToTable("Service_History");
                });

            modelBuilder.Entity("Kahuna.MVC.data.ServiceOrder", b =>
                {
                    b.Property<int>("Soid")
                        .HasColumnName("SOID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnName("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCaseClosed")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateCaseOpened")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DatePlaced")
                        .HasColumnType("datetime");

                    b.Property<string>("Decline")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Override")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Soid");

                    b.HasIndex("ClientId");

                    b.ToTable("Service_Order");
                });

            modelBuilder.Entity("Kahuna.MVC.data.Payment", b =>
                {
                    b.HasOne("Kahuna.MVC.data.ServiceOrder", "So")
                        .WithMany("Payment")
                        .HasForeignKey("Soid")
                        .HasConstraintName("FK_Payment_Service_Order")
                        .IsRequired();
                });

            modelBuilder.Entity("Kahuna.MVC.data.SalesOrderHistory", b =>
                {
                    b.HasOne("Kahuna.MVC.data.ServiceOrder", "So")
                        .WithMany("SalesOrderHistory")
                        .HasForeignKey("Soid")
                        .HasConstraintName("FK_Sales_Order_History_Service_Order")
                        .IsRequired();
                });

            modelBuilder.Entity("Kahuna.MVC.data.SalesOrderLine", b =>
                {
                    b.HasOne("Kahuna.MVC.data.Employee", "Emp")
                        .WithMany("SalesOrderLine")
                        .HasForeignKey("EmpId")
                        .HasConstraintName("FK_Sales_Order_Line_Employee")
                        .IsRequired();

                    b.HasOne("Kahuna.MVC.data.Service", "Serv")
                        .WithMany("SalesOrderLine")
                        .HasForeignKey("ServId")
                        .HasConstraintName("FK_Sales_Order_Line_Service")
                        .IsRequired();

                    b.HasOne("Kahuna.MVC.data.ServiceOrder", "So")
                        .WithMany("SalesOrderLine")
                        .HasForeignKey("Soid")
                        .HasConstraintName("FK_Sales_Order_Line_Service_Order")
                        .IsRequired();
                });

            modelBuilder.Entity("Kahuna.MVC.data.ServiceHistory", b =>
                {
                    b.HasOne("Kahuna.MVC.data.ServiceOrder", "So")
                        .WithMany("ServiceHistory")
                        .HasForeignKey("Soid")
                        .HasConstraintName("FK_Service_History_Service_Order")
                        .IsRequired();
                });

            modelBuilder.Entity("Kahuna.MVC.data.ServiceOrder", b =>
                {
                    b.HasOne("Kahuna.MVC.data.Client", "Client")
                        .WithMany("ServiceOrder")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_Service_Order_Client");
                });
#pragma warning restore 612, 618
        }
    }
}
