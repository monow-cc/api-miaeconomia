using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miaEconomiaApi.Migrations
{
    /// <inheritdoc />
    public partial class changeproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Products",
                type: "decimal(0,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostValue",
                table: "Products",
                type: "decimal(0,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(0,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CostValue",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(0,2)");

            migrationBuilder.AddColumn<int>(
                name: "Ammount",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
