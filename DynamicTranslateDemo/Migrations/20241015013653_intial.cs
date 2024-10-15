using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DynamicTranslateDemo.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterLookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property2 = table.Column<int>(type: "int", nullable: true),
                    Property3 = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildLookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Property2 = table.Column<int>(type: "int", nullable: true),
                    Property3 = table.Column<bool>(type: "bit", nullable: true),
                    MasterLookupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildLookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildLookups_MasterLookups_MasterLookupId",
                        column: x => x.MasterLookupId,
                        principalTable: "MasterLookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MasterLookups",
                columns: new[] { "Id", "Name", "Property1", "Property2", "Property3" },
                values: new object[,]
                {
                    { 1, "Software Companies", null, null, null },
                    { 2, "Countries", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ChildLookups",
                columns: new[] { "Id", "MasterLookupId", "Name", "Property1", "Property2", "Property3" },
                values: new object[,]
                {
                    { 1, 1, "Microsoft", null, null, null },
                    { 2, 1, "Oracle", null, null, null },
                    { 3, 1, "Others", null, null, null },
                    { 4, 2, "Egypt", null, null, null },
                    { 5, 2, "Palestine", null, null, null },
                    { 6, 2, "Saudi Arabia", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildLookups_MasterLookupId",
                table: "ChildLookups",
                column: "MasterLookupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildLookups");

            migrationBuilder.DropTable(
                name: "MasterLookups");
        }
    }
}
