using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shopping_list_website.Migrations
{
    /// <inheritdoc />
    public partial class addedItemData4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, "Granny Smith Apples", 5.50m, "1kg" },
                    { 2, "Fresh tomatoes", 5.90m, "500g" },
                    { 3, "Watermelon", 6.60m, "Whole" },
                    { 4, "Cucumber", 1.90m, "1 whole" },
                    { 5, "Red potato washed", 4.00m, "1kg" },
                    { 6, "Red tipped bananas", 4.90m, "1kg" },
                    { 7, "Red onion", 3.50m, "1kg" },
                    { 8, "Carrots", 2.00m, "1kg" },
                    { 9, "Iceburg Lettuce", 2.50m, "1" },
                    { 10, "Helga's Wholemeal", 3.70m, "1" },
                    { 11, "Free range chicken", 7.50m, "1kg" },
                    { 12, "Manning Valley 6-pk", 3.60m, "6 eggs" },
                    { 13, "A2 light milk", 2.90m, "1 litre" },
                    { 14, "Chobani Strawberry Yoghurt", 1.50m, "1" },
                    { 15, "Lurpak Salted Blend", 5.00m, "250g" },
                    { 16, "Bega Farmers Tasty", 4.00m, "250g" },
                    { 17, "Babybel Mini", 4.20m, "100g" },
                    { 18, "Cobram EVOO", 8.00m, "375ml" },
                    { 19, "Heinz Tomato Soup", 2.50m, "535g" },
                    { 20, "John West Tuna can", 1.50m, "95g" },
                    { 21, "Cadbury Dairy Milk", 5.00m, "200g" },
                    { 22, "Coca Cola", 2.85m, "2 litre" },
                    { 23, "Smith's Original Share Pack Crisps", 3.29m, "170g" },
                    { 24, "Birds Eye Fish Fingers", 4.50m, "375g" },
                    { 25, "Berri Orange Juice", 6.00m, "2 litre" },
                    { 26, "Vegemite", 6.00m, "380g" },
                    { 27, "Cheddar Shapes", 2.00m, "175g" },
                    { 28, "Colgate Total Toothpaste Original", 3.50m, "110g" },
                    { 29, "Milo Chocolate Malt", 4.00m, "200g" },
                    { 30, "Weet Bix Saniatarium Organic", 5.33m, "750g" },
                    { 31, "Lindt Excellence 70% Cocoa Block", 4.25m, "100g" },
                    { 32, "Original Tim Tams Choclate", 3.65m, "200g" },
                    { 33, "Philadelphia Original Cream Cheese", 4.30m, "250g" },
                    { 34, "Moccana Classic Instant Medium Roast", 6.00m, "100g" },
                    { 35, "Capilano Squeezable Honey", 7.35m, "500g" },
                    { 36, "Nutella jar", 4.00m, "400g" },
                    { 37, "Arnott's Scotch Finger", 2.85m, "250g" },
                    { 38, "South Cape Greek Feta", 5.00m, "200g" },
                    { 39, "Sacla Pasta Tomato Basil Sauce", 3.00m, "420g" },
                    { 40, "Primo English Ham", 3.00m, "100g" },
                    { 41, "Primo Short cut rindless Bacon", 5.00m, "175g" },
                    { 42, "Golden Circle Pineapple Pieces in natural juice", 3.25m, "440g" },
                    { 43, "San Remo Linguine Pasta No 1", 1.95m, "500g" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 43);
        }
    }
}
