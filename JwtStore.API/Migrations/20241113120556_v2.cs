using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtStore.API.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Role");

            migrationBuilder.CreateTable(
                name: "dbo",
                schema: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userRole",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_userRole_dbo_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Role",
                        principalTable: "dbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userRole_UserId",
                table: "userRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userRole");

            migrationBuilder.DropTable(
                name: "dbo",
                schema: "Role");
        }
    }
}
