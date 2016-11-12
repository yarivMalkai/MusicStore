using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicStore.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Albums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreID",
                table: "Albums",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Genre_GenreID",
                table: "Albums",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Genre_GenreID",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_GenreID",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Albums");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
