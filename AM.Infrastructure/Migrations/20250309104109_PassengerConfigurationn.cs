using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PassengerConfigurationn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullName_LastName",
                table: "Passengers",
                newName: "PassLastName");

            migrationBuilder.RenameColumn(
                name: "fullName_FirstName",
                table: "Passengers",
                newName: "PassFirstName");

            migrationBuilder.AlterColumn<string>(
                name: "PassLastName",
                table: "Passengers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassLastName",
                table: "Passengers",
                newName: "fullName_LastName");

            migrationBuilder.RenameColumn(
                name: "PassFirstName",
                table: "Passengers",
                newName: "fullName_FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "fullName_LastName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
