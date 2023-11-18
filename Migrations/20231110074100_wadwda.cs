using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class wadwda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "SelectedCart" },
                values: new object[] { "$2a$11$OdiC1nM4pUhXCYkAnkHt6eS2HTuksjIyAwqTpzZVQeQilZQwbWz/2", 1 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "SelectedCart" },
                values: new object[] { "$2a$11$5OcHRkuDdHQ67EnymgGaUeLKtEFiX9PQtuExFwhxFwWymCITRTO7K", 2 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "AccountId", "DateCreated", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 10, 17, 41, 0, 462, DateTimeKind.Local).AddTicks(3403), "Default" },
                    { 2, 2, new DateTime(2023, 11, 10, 17, 41, 0, 462, DateTimeKind.Local).AddTicks(3415), "Default" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "SelectedCart" },
                values: new object[] { "$2a$11$SKhP14HCBWfP86emP9/slujXYyxqma1d5P5/IWZo6AHEcIsopKrzK", null });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "SelectedCart" },
                values: new object[] { "$2a$11$9sZaAe5/1yMvLY1SV80Ppubb4nXr1knCtxkP30gTawrNztOOJ0qgO", null });
        }
    }
}
