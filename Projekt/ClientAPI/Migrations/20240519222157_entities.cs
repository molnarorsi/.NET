using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientAPI.Migrations
{
    /// <inheritdoc />
    public partial class entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fitnessId",
                table: "Fitnesses",
                newName: "fitnessID");

            migrationBuilder.CreateTable(
                name: "ClientMemberships",
                columns: table => new
                {
                    clientMembershipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clientID = table.Column<int>(type: "int", nullable: false),
                    membershipID = table.Column<int>(type: "int", nullable: false),
                    buyingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    barcode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nrOfEntries = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    isValid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    firstUsage = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fitnessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMemberships", x => x.clientMembershipID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clientName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    avatar = table.Column<byte[]>(type: "longblob", nullable: true),
                    registerDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CNP = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    barcode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    entriesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clientID = table.Column<int>(type: "int", nullable: false),
                    membershipID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    insertedByUID = table.Column<int>(type: "int", nullable: false),
                    barcode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fitnessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.entriesID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    membershipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    membershipName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    membershipPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    validityDays = table.Column<int>(type: "int", nullable: false),
                    validityEntries = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    fitnessID = table.Column<int>(type: "int", nullable: false),
                    fromHour = table.Column<int>(type: "int", nullable: false),
                    toHour = table.Column<int>(type: "int", nullable: false),
                    dailyEntriesNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.membershipID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientMemberships");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.RenameColumn(
                name: "fitnessID",
                table: "Fitnesses",
                newName: "fitnessId");
        }
    }
}
