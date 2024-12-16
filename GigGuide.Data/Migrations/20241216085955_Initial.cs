using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GigGuide.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerformanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    TicketsAvailable = table.Column<int>(type: "int", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performances_Concerts_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performances_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PerformanceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "Id", "Artist", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Green Day", "The american rock band is going on tour for their new album!", "The Saviors Tour" },
                    { 2, "GHOST", "GHOST is on a world tour and want you to join!", "World Tour 2025" },
                    { 3, "Billie Eilish", "", "Hit me hard and soft: the tour" },
                    { 4, "Sabrina Carpenter", "", "Short n´Sweet Tour" },
                    { 5, "The Offspring", "Following their eleventh studio album, The Offspring is going on tour! ", "Supercharged Worldwide in ´25" },
                    { 6, "Imagine Dragons", "Imagine Dragons are back on tour!", "LOOM World Tour" },
                    { 7, "Iron Maiden", "Iron Maiden are back on tour!", "Run for Your Lives World Tour" },
                    { 8, "OneRepublic", "OneRepublic is going on tour!", "Escape To Europe 2025" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "johanna@datababes.se", "Johanna", "Gull", "Datababesftw123", "070-6093654" },
                    { 2, "caroline@datababes.se", "Caroline", "Swanpalmer", "Bosslady123", "070-1234567" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Arenavägen 35", "Stockholm", "Sweden", "Avicii Arena" },
                    { 2, "Arenavägen 35", "Stockholm", "Sweden", "Hovet" },
                    { 3, "Gumpekullavägen 1", "Linköping", "Sweden", "Saab Arena" },
                    { 4, "Arenavägen 4", "Sandviken", "Sweden", "Göransson Arena" },
                    { 5, "John Strandrupsvei 16", "Oslo", "Norway", "Unity Arena" },
                    { 6, "Nordenskiöldinkatu 11-13", "Helsinki", "Finland", "Helsinki Jäähalli" },
                    { 7, "Hannemanns Allé 18-20", "Copenhagen", "Denmark", "Royal Arena" },
                    { 8, "Ekebergsletta", "Oslo", "Norway", "Tons of Rock" },
                    { 9, "Gärdet", "Stockholm", "Sweden", "STHLM Fields" },
                    { 10, "Tusindårsskoven", "Falen, Odense V", "Denmark", "Tinderbox" },
                    { 11, "Arenaslingan 14", "Stockholm", "Sweden", "Tele2 Arena" },
                    { 12, "Stiklestadveien 2", "Trondheim", "Norway", "Bryggeribyen - EC Dahls Arena" }
                });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "Id", "ConcertId", "PerformanceTime", "TicketPrice", "TicketsAvailable", "VenueId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), 895, 8000, 9 },
                    { 2, 1, new DateTime(2025, 6, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), 1200, 10000, 8 },
                    { 3, 1, new DateTime(2025, 6, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), 895, 7000, 10 },
                    { 4, 2, new DateTime(2025, 5, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 895, 6000, 3 },
                    { 5, 2, new DateTime(2025, 5, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 895, 8000, 4 },
                    { 6, 2, new DateTime(2025, 5, 17, 20, 0, 0, 0, DateTimeKind.Unspecified), 895, 10000, 7 },
                    { 7, 3, new DateTime(2025, 4, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 1295, 60000, 1 },
                    { 8, 3, new DateTime(2025, 4, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), 1295, 60000, 1 },
                    { 9, 3, new DateTime(2025, 4, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), 1295, 35000, 5 },
                    { 10, 3, new DateTime(2025, 4, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), 1295, 35000, 7 },
                    { 11, 4, new DateTime(2025, 4, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 1095, 60000, 1 },
                    { 12, 4, new DateTime(2025, 4, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 1095, 60000, 1 },
                    { 13, 4, new DateTime(2025, 3, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 1095, 35000, 5 },
                    { 14, 4, new DateTime(2025, 3, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), 1095, 35000, 7 },
                    { 15, 4, new DateTime(2025, 4, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 1095, 35000, 7 },
                    { 16, 5, new DateTime(2025, 10, 9, 19, 30, 0, 0, DateTimeKind.Unspecified), 1095, 20000, 2 },
                    { 17, 5, new DateTime(2025, 10, 10, 19, 30, 0, 0, DateTimeKind.Unspecified), 1095, 20000, 5 },
                    { 18, 6, new DateTime(2025, 6, 5, 19, 30, 0, 0, DateTimeKind.Unspecified), 1095, 40000, 11 },
                    { 19, 7, new DateTime(2025, 6, 12, 19, 30, 0, 0, DateTimeKind.Unspecified), 1495, 40000, 11 },
                    { 20, 7, new DateTime(2025, 6, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), 1495, 40000, 11 },
                    { 21, 7, new DateTime(2025, 6, 5, 19, 30, 0, 0, DateTimeKind.Unspecified), 1495, 40000, 12 },
                    { 22, 7, new DateTime(2025, 6, 9, 19, 30, 0, 0, DateTimeKind.Unspecified), 1495, 40000, 7 },
                    { 23, 8, new DateTime(2025, 10, 31, 19, 30, 0, 0, DateTimeKind.Unspecified), 1195, 40000, 1 },
                    { 24, 8, new DateTime(2025, 10, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), 1195, 40000, 7 },
                    { 25, 8, new DateTime(2025, 11, 1, 19, 30, 0, 0, DateTimeKind.Unspecified), 1195, 40000, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PerformanceId",
                table: "Bookings",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_ConcertId",
                table: "Performances",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_VenueId",
                table: "Performances",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
