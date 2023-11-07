using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class ba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLines_sSoppingCarts_ShoppingCartId",
                table: "ShoppingCartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_sSoppingCarts_Accounts_AccountId",
                table: "sSoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sSoppingCarts",
                table: "sSoppingCarts");

            migrationBuilder.RenameTable(
                name: "sSoppingCarts",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_sSoppingCarts_AccountId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLines_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartLines",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Accounts_AccountId",
                table: "ShoppingCarts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLines_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Accounts_AccountId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "sSoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_AccountId",
                table: "sSoppingCarts",
                newName: "IX_sSoppingCarts_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sSoppingCarts",
                table: "sSoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLines_sSoppingCarts_ShoppingCartId",
                table: "ShoppingCartLines",
                column: "ShoppingCartId",
                principalTable: "sSoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sSoppingCarts_Accounts_AccountId",
                table: "sSoppingCarts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
