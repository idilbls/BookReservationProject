using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReservationProject.Data.Migrations
{
    public partial class Borrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    BorrowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    ReaderId = table.Column<int>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_Borrow_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrow_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "ReaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookId",
                table: "Borrow",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_ReaderId",
                table: "Borrow",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    BorrowHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.BorrowHistoryId);
                    table.ForeignKey(
                        name: "FK_Borrow_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrow_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "ReaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookId",
                table: "Borrow",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_ReaderId",
                table: "Borrow",
                column: "ReaderId");
        }
    }
}
