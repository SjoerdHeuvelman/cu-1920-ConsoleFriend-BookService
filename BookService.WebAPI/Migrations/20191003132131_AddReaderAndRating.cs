﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookService.WebAPI.Migrations
{
    public partial class AddReaderAndRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    ReaderId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Sharp" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophie", "Netty" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elisa", "Yammy" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "UK", "IT-publishers" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 2, "Sweden", "FoodBooks" });

            migrationBuilder.InsertData(
                table: "Reader",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Joe", "Pageturner" });

            migrationBuilder.InsertData(
                table: "Reader",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Linda", "Bookslaughter" });

            migrationBuilder.InsertData(
                table: "Reader",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 3, "Wendy", "Allreader" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 1, 1, "book1.jpg", "123456789", 420, 24.99m, 1, "Learning C#", 2018 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 2, 2, "book2.jpg", "45689132", 360, 35.99m, 1, "Mastering Linq", 2016 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 3, 1, "book3.jpg", "15856135", 360, 50.00m, 1, "Mastering Xamarin", 2017 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 4, 2, "book1.jpg", "56789564", 360, 45.00m, 1, "Exploring ASP.Net Core 2.0", 2018 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 5, 2, "book2.jpg", "234546684", 420, 70.50m, 1, "Unity Game Development", 2017 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 6, 3, "book3.jpg", "789456258", 40, 52.00m, 2, "Cooking is fun", 2007 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 7, 3, "book3.jpg", "94521546", 53, 30.00m, 2, "Secret recipes", 2017 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "ReaderId", "Score" },
                values: new object[] { 1, 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "ReaderId", "Score" },
                values: new object[] { 4, 1, 2, 4 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "ReaderId", "Score" },
                values: new object[] { 2, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "ReaderId", "Score" },
                values: new object[] { 5, 2, 3, 2 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "ReaderId", "Score" },
                values: new object[] { 3, 3, 2, 5 });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "BookId", "ReaderId", "Score" },
                values: new object[] { 6, 3, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BookId",
                table: "Rating",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ReaderId",
                table: "Rating",
                column: "ReaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Sharp" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophie", "Netty" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elisa", "Yammy" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "UK", "IT-publishers" });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 2, "Sweden", "FoodBooks" });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 1, 1, "book1.jpg", "123456789", 420, 24.99m, 1, "Learning C#", 2018 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 2, 2, "book2.jpg", "45689132", 360, 35.99m, 1, "Mastering Linq", 2016 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 3, 1, "book3.jpg", "15856135", 360, 50.00m, 1, "Mastering Xamarin", 2017 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 4, 2, "book1.jpg", "56789564", 360, 45.00m, 1, "Exploring ASP.Net Core 2.0", 2018 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 5, 2, "book2.jpg", "234546684", 420, 70.50m, 1, "Unity Game Development", 2017 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 6, 3, "book3.jpg", "789456258", 40, 52.00m, 2, "Cooking is fun", 2007 });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "FileName", "ISBN", "NumberOfPages", "Price", "PublisherId", "Title", "Year" },
                values: new object[] { 7, 3, "book3.jpg", "94521546", 53, 30.00m, 2, "Secret recipes", 2017 });
        }
    }
}
