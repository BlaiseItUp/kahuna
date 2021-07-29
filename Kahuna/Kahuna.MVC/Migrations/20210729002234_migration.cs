using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kahuna.MVC.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false),
                    CFName = table.Column<string>(maxLength: 50, nullable: false),
                    CLName = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(name: "Address(...)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(fixedLength: true, maxLength: 5, nullable: false),
                    CriminalRecord = table.Column<string>(maxLength: 50, nullable: true),
                    Military = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false),
                    EFName = table.Column<string>(maxLength: 50, nullable: false),
                    ELName = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Position = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServID = table.Column<int>(nullable: false),
                    ServName = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServID);
                });

            migrationBuilder.CreateTable(
                name: "Service_Order",
                columns: table => new
                {
                    SOID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: true),
                    DatePlaced = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCaseOpened = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCaseClosed = table.Column<DateTime>(type: "datetime", nullable: true),
                    Override = table.Column<string>(maxLength: 50, nullable: true),
                    Decline = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Order", x => x.SOID);
                    table.ForeignKey(
                        name: "FK_Service_Order_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    SOID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Service_Order",
                        column: x => x.SOID,
                        principalTable: "Service_Order",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales_Order_History",
                columns: table => new
                {
                    HistID = table.Column<int>(nullable: false),
                    SOID = table.Column<int>(nullable: false),
                    EmpID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_Order_History", x => x.HistID);
                    table.ForeignKey(
                        name: "FK_Sales_Order_History_Service_Order",
                        column: x => x.SOID,
                        principalTable: "Service_Order",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales_Order_Line",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false),
                    SOID = table.Column<int>(nullable: false),
                    ServID = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_Order_Line", x => new { x.EmpID, x.SOID, x.ServID });
                    table.ForeignKey(
                        name: "FK_Sales_Order_Line_Employee",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Order_Line_Service",
                        column: x => x.ServID,
                        principalTable: "Service",
                        principalColumn: "ServID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Order_Line_Service_Order",
                        column: x => x.SOID,
                        principalTable: "Service_Order",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service_History",
                columns: table => new
                {
                    SHID = table.Column<int>(nullable: false),
                    SOID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyingUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_History", x => x.SHID);
                    table.ForeignKey(
                        name: "FK_Service_History_Service_Order",
                        column: x => x.SOID,
                        principalTable: "Service_Order",
                        principalColumn: "SOID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SOID",
                table: "Payment",
                column: "SOID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Order_History_SOID",
                table: "Sales_Order_History",
                column: "SOID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Order_Line_ServID",
                table: "Sales_Order_Line",
                column: "ServID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Order_Line_SOID",
                table: "Sales_Order_Line",
                column: "SOID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_History_SOID",
                table: "Service_History",
                column: "SOID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Order_ClientID",
                table: "Service_Order",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Sales_Order_History");

            migrationBuilder.DropTable(
                name: "Sales_Order_Line");

            migrationBuilder.DropTable(
                name: "Service_History");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Service_Order");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
