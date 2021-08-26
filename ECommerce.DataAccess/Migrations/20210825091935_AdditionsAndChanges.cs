using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.DataAccess.Migrations
{
    public partial class AdditionsAndChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Rule");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "RelatedProducts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "ProductGroupLines");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "FavoriteProducts");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "ExchangeRateHistories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AccountAddresses");

            migrationBuilder.RenameColumn(
                name: "ProductGroupId",
                table: "Products",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                newName: "IX_Products_CurrencyId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<int>(
                name: "VatRate",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "ProductGroupLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductGroupLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Brands",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Gsm",
                table: "Accounts",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AccountAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Url",
                table: "Products",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupLines_ProductGroupId",
                table: "ProductGroupLines",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupLines_ProductId",
                table: "ProductGroupLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Url",
                table: "Categories",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Url",
                table: "Brands",
                column: "Url",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroupLines_ProductGroups_ProductGroupId",
                table: "ProductGroupLines",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroupLines_Products_ProductId",
                table: "ProductGroupLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Currencies_CurrencyId",
                table: "Products",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroupLines_ProductGroups_ProductGroupId",
                table: "ProductGroupLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroupLines_Products_ProductId",
                table: "ProductGroupLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Currencies_CurrencyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Url",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroupLines_ProductGroupId",
                table: "ProductGroupLines");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroupLines_ProductId",
                table: "ProductGroupLines");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Url",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Url",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "ProductGroupLines");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductGroupLines");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AccountAddresses");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Products",
                newName: "ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CurrencyId",
                table: "Products",
                newName: "IX_Products_ProductGroupId");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "UserGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Rule",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "RelatedProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "ProductGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "ProductGroupLines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Genders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "FavoriteProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "ExchangeRateHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Gsm",
                table: "Accounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AccountAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
