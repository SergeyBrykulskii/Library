using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class final_db_version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "Surname" },
                values: new object[,]
                {
                    { new Guid("5d836356-e43b-421d-985e-add2a4b341db"), "Leo", "Tolstoy" },
                    { new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"), "Ray", "Bradbury" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "authorId", "Description", "genreId", "ISBN", "RecieveDate", "ReturnDate", "Title" },
                values: new object[,]
                {
                    {
                        new Guid("295dbecc-3bac-4b46-934a-1b4dabdab24e"),
                        new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"),
                        "Nearly seventy years after its original publication," +
                        " Ray Bradbury’s internationally acclaimed novel Fahrenheit 451 stands" +
                        " as a classic of world literature set in a bleak, dystopian future." +
                        " Today its message has grown more relevant than ever before",
                        "Dystopian",
                        "978-0-006-54606-1",
                        new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2970),
                        new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2980),
                        "Fahrenheit 451"
                    },
                    {
                        new Guid("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"),
                        new Guid("5d836356-e43b-421d-985e-add2a4b341db"),
                        "War and Peace is a vast epic centred on Napoleon's war with Russia.",
                        "Historical novel",
                        "978-9-464-81540-5",
                        new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2984),
                        new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2985),
                        "War and Peace" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("295dbecc-3bac-4b46-934a-1b4dabdab24e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5d836356-e43b-421d-985e-add2a4b341db"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"));
        }
    }
}
