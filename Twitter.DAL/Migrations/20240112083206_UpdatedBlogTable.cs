using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.DAL.Migrations
{
    public partial class UpdatedBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 12, 12, 32, 6, 512, DateTimeKind.Local).AddTicks(1369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 8, 13, 8, 19, 700, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 12, 8, 32, 6, 511, DateTimeKind.Utc).AddTicks(8005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 8, 9, 8, 19, 699, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 12, 12, 32, 6, 511, DateTimeKind.Local).AddTicks(7392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 8, 13, 8, 19, 699, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId1",
                table: "Comments",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId",
                table: "Blogs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Blogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Topics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 8, 13, 8, 19, 700, DateTimeKind.Local).AddTicks(2590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 12, 12, 32, 6, 512, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 8, 9, 8, 19, 699, DateTimeKind.Utc).AddTicks(9721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 12, 8, 32, 6, 511, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 8, 13, 8, 19, 699, DateTimeKind.Local).AddTicks(9174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 12, 12, 32, 6, 511, DateTimeKind.Local).AddTicks(7392));
        }
    }
}
