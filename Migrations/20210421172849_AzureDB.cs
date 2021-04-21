using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scheduling.Migrations
{
    public partial class AzureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermisionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Accountant" },
                    { 3, "Part-time" },
                    { 4, "Full-time" },
                    { 5, "Access to reports" },
                    { 6, "Access to calendar" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 6, 1321313, "Development" });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "PermisionId", "UserId" },
                values: new object[,]
                {
                    { 3, 1, 1321313 },
                    { 4, 3, 13213133 },
                    { 5, 2, 1321313 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Department", "Email", "Name", "Password", "Position", "Salt", "Surname" },
                values: new object[,]
                {
                    { 1321313, "Memes", "admin@gmail.com", "Admin", "5dj3bhWCfxuHmONkBdvFrA==", "lol", "91ed90df-3289-4fdf-a927-024b24bea8b7", "Adminov" },
                    { 13213133, "Memes", "user@gmail.com", "User", "u9DAYiHl+liIqRMvuuciBA==", "lol", "f0e30e73-fac3-4182-8641-ecba862fed69", "Userov" }
                });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "Id", "Comment", "FinishDate", "StartDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "I want to see a bober.", new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Declined. Declined by PM. Declined by TL.", 13213133 },
                    { 2, "I really want to see a bober.", new DateTime(2021, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Declined. Declined by PM. Declined by TL.", 13213133 },
                    { 3, "Please, it`s my dream to see a bober.", new DateTime(2021, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending consideration...", 13213133 }
                });

            migrationBuilder.InsertData(
                table: "userTeams",
                columns: new[] { "Id", "TeamId", "UserId" },
                values: new object[] { 1, 6, 13213133 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "userTeams");

            migrationBuilder.DropTable(
                name: "VacationRequests");
        }
    }
}
