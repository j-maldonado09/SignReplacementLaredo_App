using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignReplacementLaredo_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactOrganizationType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceSectionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactLastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactOrganizationType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaintenanceSectionId",
                table: "AspNetUsers");
        }
    }
}
