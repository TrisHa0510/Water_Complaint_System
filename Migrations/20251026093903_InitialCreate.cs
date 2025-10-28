using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WaterComplaintSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Area = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    WardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResolvedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CitizenId = table.Column<int>(type: "INTEGER", nullable: false),
                    WardId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedWorkerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Workers_AssignedWorkerId",
                        column: x => x.AssignedWorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ComplaintId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintPhotos_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main Street, Ward 1", "alice.w@email.com", "Alice Williams", "9123456780" },
                    { 2, "456 Oak Avenue, Ward 2", "bob.m@email.com", "Bob Miller", "9123456781" },
                    { 3, "789 Pine Road, Ward 3", "carol.g@email.com", "Carol Garcia", "9123456782" },
                    { 4, "321 Elm Street, Ward 4", "david.m@email.com", "David Martinez", "9123456783" },
                    { 5, "654 Maple Drive, Ward 5", "eva.a@email.com", "Eva Anderson", "9123456784" }
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "Area", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Central Business District", "Downtown commercial area", "Ward 1" },
                    { 2, "Residential North", "Northern residential zone", "Ward 2" },
                    { 3, "Industrial East", "Eastern industrial sector", "Ward 3" },
                    { 4, "Suburban South", "Southern suburban area", "Ward 4" },
                    { 5, "Commercial West", "Western commercial district", "Ward 5" }
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "AssignedWorkerId", "CitizenId", "CreatedDate", "Description", "Priority", "ResolvedDate", "Status", "Title", "WardId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 10, 24, 15, 9, 1, 373, DateTimeKind.Local).AddTicks(9850), "Water supply completely stopped from 6 AM today", "High", null, "Pending", "No water supply since morning", 1 },
                    { 3, null, 3, new DateTime(2025, 10, 25, 15, 9, 1, 373, DateTimeKind.Local).AddTicks(9862), "Water coming out is brownish in color", "Critical", null, "Pending", "Dirty water supply", 3 },
                    { 5, null, 5, new DateTime(2025, 10, 19, 15, 9, 1, 373, DateTimeKind.Local).AddTicks(9873), "Water supply timing not consistent", "Low", null, "Pending", "Irregular water timing", 5 }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Email", "Name", "Phone", "WardId" },
                values: new object[,]
                {
                    { 1, "john.smith@municipal.gov", "John Smith", "9876543210", 1 },
                    { 2, "sarah.johnson@municipal.gov", "Sarah Johnson", "9876543211", 2 },
                    { 3, "michael.brown@municipal.gov", "Michael Brown", "9876543212", 3 },
                    { 4, "emily.davis@municipal.gov", "Emily Davis", "9876543213", 4 },
                    { 5, "robert.wilson@municipal.gov", "Robert Wilson", "9876543214", 5 }
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "AssignedWorkerId", "CitizenId", "CreatedDate", "Description", "Priority", "ResolvedDate", "Status", "Title", "WardId" },
                values: new object[,]
                {
                    { 2, 2, 2, new DateTime(2025, 10, 21, 15, 9, 1, 373, DateTimeKind.Local).AddTicks(9859), "Water pressure very low, difficult to use", "Medium", null, "InProgress", "Low water pressure", 2 },
                    { 4, 4, 4, new DateTime(2025, 10, 16, 15, 9, 1, 373, DateTimeKind.Local).AddTicks(9865), "Major pipeline leak on the street", "High", new DateTime(2025, 10, 23, 15, 9, 1, 373, DateTimeKind.Local).AddTicks(9866), "Resolved", "Pipeline leakage", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintPhotos_ComplaintId",
                table: "ComplaintPhotos",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AssignedWorkerId",
                table: "Complaints",
                column: "AssignedWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_CitizenId",
                table: "Complaints",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_WardId",
                table: "Complaints",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WardId",
                table: "Workers",
                column: "WardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintPhotos");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Wards");
        }
    }
}
