using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicTranslateDemo.Migrations
{
    /// <inheritdoc />
    public partial class intial_translation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Translation");

            migrationBuilder.CreateTable(
                name: "OverrideTranslations",
                schema: "Translation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Entity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Property = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverrideTranslations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OverrideTranslationDetails",
                schema: "Translation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OverrideTranslationId = table.Column<long>(type: "bigint", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverrideTranslationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverrideTranslationDetails_OverrideTranslations_OverrideTranslationId",
                        column: x => x.OverrideTranslationId,
                        principalSchema: "Translation",
                        principalTable: "OverrideTranslations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OverrideTranslationDetails_OverrideTranslationId",
                schema: "Translation",
                table: "OverrideTranslationDetails",
                column: "OverrideTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_OverrideTranslations_Entity_Property_Key",
                schema: "Translation",
                table: "OverrideTranslations",
                columns: new[] { "Entity", "Property", "Key" },
                unique: true,
                filter: "[Entity] IS NOT NULL AND [Property] IS NOT NULL AND [Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OverrideTranslations_Text",
                schema: "Translation",
                table: "OverrideTranslations",
                column: "Text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OverrideTranslationDetails",
                schema: "Translation");

            migrationBuilder.DropTable(
                name: "OverrideTranslations",
                schema: "Translation");
        }
    }
}
