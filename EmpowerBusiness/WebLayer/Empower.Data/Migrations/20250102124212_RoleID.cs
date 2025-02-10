using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empower.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure a default role exists in UserRoles
            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM UserRoles WHERE Id = 1) " +
                                 "INSERT INTO [dbo].[userroles] ([name], [description], [isactive], [uniqueid], [createdby], [createdon], [lastmodifiedby], [lastmodifiedon], [isdeleted], [deletedby], [deletedon]) VALUES ('Admin', 'Administrator role with full access', 1, NEWID(), 1, GETDATE(), NULL, NULL, 0, NULL, NULL);");

            // Drop the existing foreign key
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            // Alter the UserRoleId column to be non-nullable with a default value of 1
            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1, // Ensure this value exists in UserRoles
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            // Add the foreign key constraint back with Cascade on delete
            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            // Revert the UserRoleId column to be nullable
            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Re-add the foreign key without Cascade on delete
            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

    }
}
