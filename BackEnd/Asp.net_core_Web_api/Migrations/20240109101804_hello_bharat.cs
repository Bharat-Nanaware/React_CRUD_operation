using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace React_assignment_1_web_api.Migrations
{
    public partial class hello_bharat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserOrderedFood",
                newName: "UserOrderedFoodID");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "UserOrderedFood",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "MealSummery",
                columns: table => new
                {
                    MealsummeryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealSummeryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealsummeryDescription_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealsummeryDescription_2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealSummery", x => x.MealsummeryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealSummery");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "UserOrderedFood");

            migrationBuilder.RenameColumn(
                name: "UserOrderedFoodID",
                table: "UserOrderedFood",
                newName: "ID");
        }
    }
}
