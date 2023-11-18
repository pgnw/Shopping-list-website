using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class addedQuantity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
