using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.DAL.Migrations
{
    public partial class ModeloEstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEstausVenta",
                table: "Estatus",
                newName: "IdEstatusVenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEstatusVenta",
                table: "Estatus",
                newName: "IdEstausVenta");
        }
    }
}
