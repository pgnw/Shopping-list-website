using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class addedQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCartLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ABbq59Co.d9iEVFXWU83MeDxNC4Gh3UXIaT.59Yhu1B/WeqYPsxG6");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$2Vwo/d3cm2TJ2WcBEHX8bu2E2TZ3DT3iL.0uv3CLB01EcQD9fI8EO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCartLines");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "a");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "a");
        }
    }
}
