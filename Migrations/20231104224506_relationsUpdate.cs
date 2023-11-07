using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class relationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartLines_items_ItemId",
                table: "shoppingCartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartLines_shoppingCarts_ShoppingCartId",
                table: "shoppingCartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_accounts_AccountId",
                table: "shoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCartLines",
                table: "shoppingCartLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts");

            migrationBuilder.RenameTable(
                name: "shoppingCartLines",
                newName: "ShoppingCartLines");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Accounts");

            migrationBuilder.RenameTable(
                name: "shoppingCarts",
                newName: "sSoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCartLines_ShoppingCartId",
                table: "ShoppingCartLines",
                newName: "IX_ShoppingCartLines_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCartLines_ItemId",
                table: "ShoppingCartLines",
                newName: "IX_ShoppingCartLines_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCarts_AccountId",
                table: "sSoppingCarts",
                newName: "IX_sSoppingCarts_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartLines",
                table: "ShoppingCartLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sSoppingCarts",
                table: "sSoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLines_Items_ItemId",
                table: "ShoppingCartLines",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLines_Items_ItemId",
                table: "ShoppingCartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLines_sSoppingCarts_ShoppingCartId",
                table: "ShoppingCartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_sSoppingCarts_Accounts_AccountId",
                table: "sSoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartLines",
                table: "ShoppingCartLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sSoppingCarts",
                table: "sSoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCartLines",
                newName: "shoppingCartLines");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "items");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "accounts");

            migrationBuilder.RenameTable(
                name: "sSoppingCarts",
                newName: "shoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartLines_ShoppingCartId",
                table: "shoppingCartLines",
                newName: "IX_shoppingCartLines_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartLines_ItemId",
                table: "shoppingCartLines",
                newName: "IX_shoppingCartLines_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_sSoppingCarts_AccountId",
                table: "shoppingCarts",
                newName: "IX_shoppingCarts_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCartLines",
                table: "shoppingCartLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCarts",
                table: "shoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartLines_items_ItemId",
                table: "shoppingCartLines",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartLines_shoppingCarts_ShoppingCartId",
                table: "shoppingCartLines",
                column: "ShoppingCartId",
                principalTable: "shoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_accounts_AccountId",
                table: "shoppingCarts",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
