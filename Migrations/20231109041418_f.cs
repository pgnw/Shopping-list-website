using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$SKhP14HCBWfP86emP9/slujXYyxqma1d5P5/IWZo6AHEcIsopKrzK");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$9sZaAe5/1yMvLY1SV80Ppubb4nXr1knCtxkP30gTawrNztOOJ0qgO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CRaG0/bD3xLgxobF0znMku/IVwLRlOnC7eCnEpdpM..dszWjQim0i");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$UT5OtEyGcJLRP2RSycBxmOgf5gBZNbqznNzfCf3mAVgUX9f2Lqpfq");
        }
    }
}
