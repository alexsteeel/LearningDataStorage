using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningDataStorage.DAL.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var dbName = "LDS";
            var fileTablesPath = @"C:\FileStorage";

            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.EnsureSchema(
                name: "file");

            migrationBuilder.EnsureSchema(
                name: "srv");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Biography = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbFiles",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamGuid = table.Column<Guid>(nullable: false),
                    FileTable = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouses",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "srv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Alpha3Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "srv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ISO639Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthorPhoto",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthorPhoto_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "data",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MainPageLinkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Links_MainPageLinkId",
                        column: x => x.MainPageLinkId,
                        principalSchema: "data",
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "srv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "srv",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Annotation = table.Column<string>(maxLength: 1000, nullable: false),
                    PagesCount = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    PublishingHouseId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "srv",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "srv",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_PublishingHouses_PublishingHouseId",
                        column: x => x.PublishingHouseId,
                        principalSchema: "data",
                        principalTable: "PublishingHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthorLinks",
                schema: "data",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorLinks", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthorLinks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "data",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthorLinks_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "data",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "data",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookQuotes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    PageNumber = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookQuotes_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "data",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRatings",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    MaxValue = table.Column<decimal>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRatings_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "data",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRatings_Sites_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "data",
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCovers",
                schema: "file",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCovers_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "data",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCovers_DbFiles_FileId",
                        column: x => x.FileId,
                        principalSchema: "data",
                        principalTable: "DbFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    BookQuoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "data",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_BookQuotes_BookQuoteId",
                        column: x => x.BookQuoteId,
                        principalSchema: "data",
                        principalTable: "BookQuotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "srv",
                table: "Countries",
                columns: new[] { "Id", "Alpha3Code", "Name" },
                values: new object[,]
                {
                    { 1, "RUS", "Russian Federation" },
                    { 2, "USA", "United States of America" }
                });

            migrationBuilder.InsertData(
                schema: "srv",
                table: "Languages",
                columns: new[] { "Id", "ISO639Code", "Name" },
                values: new object[,]
                {
                    { 1, "eng", "English" },
                    { 2, "rus", "Russian" }
                });

            migrationBuilder.InsertData(
                schema: "srv",
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Moscow" });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorLinks_AuthorId",
                schema: "data",
                table: "BookAuthorLinks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorPhoto_AuthorId",
                schema: "data",
                table: "BookAuthorPhoto",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_BookId",
                schema: "data",
                table: "BookCategories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookQuotes_BookId",
                schema: "data",
                table: "BookQuotes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_BookId",
                schema: "data",
                table: "BookRatings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_SiteId",
                schema: "data",
                table: "BookRatings",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CityId",
                schema: "data",
                table: "Books",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                schema: "data",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingHouseId",
                schema: "data",
                table: "Books",
                column: "PublishingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BookId",
                schema: "data",
                table: "Notes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BookQuoteId",
                schema: "data",
                table: "Notes",
                column: "BookQuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_MainPageLinkId",
                schema: "data",
                table: "Sites",
                column: "MainPageLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCovers_BookId",
                schema: "file",
                table: "BookCovers",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCovers_FileId",
                schema: "file",
                table: "BookCovers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                schema: "srv",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.Sql(
            @$"
	            ALTER DATABASE {dbName}  
	            SET FILESTREAM ( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'FilesStore' );  
	            GO  

	            ALTER DATABASE {dbName}
	            ADD FILEGROUP fsGroup CONTAINS FILESTREAM;
	            GO

	            ALTER DATABASE {dbName}
	            ADD FILE
	              ( NAME = 'fsLdsDB', FILENAME = '{fileTablesPath}'
	               )
	            TO FILEGROUP fsGroup;
	            GO

	            CREATE TABLE AuthorsPhotoStore AS FileTable
	            WITH
	            (
		            FileTable_Directory = 'AuthorsPhoto',
		            FileTable_Collate_Filename = database_default
	            );
	            GO
	
	            CREATE TABLE BookCoversStore AS FileTable
	            WITH
	            (
		            FileTable_Directory = 'BookCovers',
		            FileTable_Collate_Filename = database_default
	            );
	            GO
	
CREATE PROCEDURE [file].GetAuthorsPhotoGuid
	@FileName NVARCHAR(MAX),
	@FileGuid UNIQUEIDENTIFIER OUTPUT
AS
BEGIN

	SET @FileGuid = 
	(
		SELECT A.[stream_id]
		FROM [dbo].[AuthorsPhotoStore] AS A
        WITH(READCOMMITTEDLOCK)
		WHERE A.[name] = @FileName
	);

END
GO

CREATE PROCEDURE [file].GetBookCoverGuid
	@FileName NVARCHAR(MAX),
	@FileGuid UNIQUEIDENTIFIER OUTPUT
AS
BEGIN

	SET @FileGuid = 
	(
		SELECT A.[stream_id]
		FROM [dbo].[BookCoversStore] AS A
        WITH(READCOMMITTEDLOCK)
		WHERE A.[name] = @FileName
	);

END
            ", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorLinks",
                schema: "data");

            migrationBuilder.DropTable(
                name: "BookAuthorPhoto",
                schema: "data");

            migrationBuilder.DropTable(
                name: "BookCategories",
                schema: "data");

            migrationBuilder.DropTable(
                name: "BookRatings",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "BookCovers",
                schema: "file");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Sites",
                schema: "data");

            migrationBuilder.DropTable(
                name: "BookQuotes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "DbFiles",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Links",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "srv");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "srv");

            migrationBuilder.DropTable(
                name: "PublishingHouses",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "srv");
        }
    }
}
