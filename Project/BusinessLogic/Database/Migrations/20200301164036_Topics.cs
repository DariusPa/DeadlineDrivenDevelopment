using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Topics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningDays_Topic_TopicId",
                table: "LearningDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "LearningDays");

            migrationBuilder.DropColumn(
                name: "References",
                table: "LearningDays");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Topics",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExtraInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Links = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraInformation_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TopicId",
                table: "Topics",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraInformation_TopicId",
                table: "ExtraInformation",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningDays_Topics_TopicId",
                table: "LearningDays",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Topics_TopicId",
                table: "Topics",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningDays_Topics_TopicId",
                table: "LearningDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Topics_TopicId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "ExtraInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TopicId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Topics");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "LearningDays",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "References",
                table: "LearningDays",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningDays_Topic_TopicId",
                table: "LearningDays",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
