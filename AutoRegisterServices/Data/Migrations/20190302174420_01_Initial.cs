using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoRegisterServices.Migrations
{
    public partial class _01_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastNmae = table.Column<string>(nullable: true),
                    Age = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastNmae = table.Column<string>(nullable: true),
                    Age = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Age", "FirstName", "LastNmae" },
                values: new object[,]
                {
                    { new Guid("8eb13787-0273-4fa6-a21d-4be5ff0853e7"), (byte)26, "Sinjul", "MSBH" },
                    { new Guid("94891122-ffb8-4d5b-96bc-d96e3d80d052"), (byte)26, "Jack", "Slater" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "Age", "FirstName", "LastNmae" },
                values: new object[,]
                {
                    { new Guid("23734e12-1b8a-45b1-b131-ce8a7e0e2836"), (byte)26, "Sinjul", "MSBH" },
                    { new Guid("fada6115-01b9-4025-8cde-31c720cb7567"), (byte)26, "Jack", "Slater" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
