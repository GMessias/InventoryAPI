using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIInventory.Migrations
{
    public partial class StatsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usable = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enchanted = table.Column<bool>(type: "bit", nullable: true),
                    TypeWeapon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeAttack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ammunition = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attack = table.Column<double>(type: "float", nullable: false),
                    MagicAttack = table.Column<double>(type: "float", nullable: false),
                    Defense = table.Column<double>(type: "float", nullable: false),
                    MagicDefense = table.Column<double>(type: "float", nullable: false),
                    Evade = table.Column<double>(type: "float", nullable: false),
                    Block = table.Column<double>(type: "float", nullable: false),
                    Resistance = table.Column<double>(type: "float", nullable: false),
                    EquipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Items_EquipId",
                        column: x => x.EquipId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stats_EquipId",
                table: "Stats",
                column: "EquipId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
