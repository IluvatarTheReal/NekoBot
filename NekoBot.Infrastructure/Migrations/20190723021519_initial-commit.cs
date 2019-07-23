using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NekoBot.Infrastructure.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModerationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    TargetedUserId = table.Column<ulong>(nullable: false),
                    TargetUsername = table.Column<string>(nullable: true),
                    ExecutingUserId = table.Column<ulong>(nullable: false),
                    ExecutingUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModerationLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModerationLogs");
        }
    }
}
