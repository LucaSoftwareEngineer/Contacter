using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "utenti",
                columns: table => new
                {
                    ute_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ute_email = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    ute_pass = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utenti", x => x.ute_id);
                });

            migrationBuilder.CreateTable(
                name: "contatti",
                columns: table => new
                {
                    con_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    con_nome = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    con_email = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    con_tel = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    con_ute_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatti", x => x.con_id);
                    table.ForeignKey(
                        name: "FK_contatti_utenti",
                        column: x => x.con_ute_id,
                        principalTable: "utenti",
                        principalColumn: "ute_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatti_con_ute_id",
                table: "contatti",
                column: "con_ute_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contatti");

            migrationBuilder.DropTable(
                name: "utenti");
        }
    }
}
