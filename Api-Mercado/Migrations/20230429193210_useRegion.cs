using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Mercado.Migrations
{
    /// <inheritdoc />
    public partial class useRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "Markets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Markets");
        }
    }
}
