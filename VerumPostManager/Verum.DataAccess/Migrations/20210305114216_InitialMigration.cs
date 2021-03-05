using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Verum.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedLetters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedLetters_Customers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivedLetters_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivedLetters_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SentLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ConfirmationOfSending = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentLetters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentLetters_Customers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SentLetters_Customers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SentLetters_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedLetters_EmployeeId",
                table: "ReceivedLetters",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedLetters_RecipientId",
                table: "ReceivedLetters",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedLetters_SenderId",
                table: "ReceivedLetters",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SentLetters_EmployeeId",
                table: "SentLetters",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SentLetters_RecipientId",
                table: "SentLetters",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_SentLetters_SenderId",
                table: "SentLetters",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedLetters");

            migrationBuilder.DropTable(
                name: "SentLetters");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
