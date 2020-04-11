using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningDataStorage.DAL.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dt");

            migrationBuilder.EnsureSchema(
                name: "file");

            migrationBuilder.EnsureSchema(
                name: "srv");

            migrationBuilder.CreateTable(
                name: "DbFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamGuid = table.Column<Guid>(nullable: false),
                    FileTable = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    FileType = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                schema: "dt",
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
                schema: "dt",
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
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MainPageLinkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Links_MainPageLinkId",
                        column: x => x.MainPageLinkId,
                        principalSchema: "dt",
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
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 1000, nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    PublishingHouseId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    PagesCount = table.Column<int>(nullable: false)
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
                        principalSchema: "dt",
                        principalTable: "PublishingHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 100, nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dt",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageNumber = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dt",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRatings",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: false),
                    MaxValue = table.Column<decimal>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRatings_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dt",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookRatings_Sites_SiteId",
                        column: x => x.SiteId,
                        principalSchema: "dt",
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
                        principalSchema: "dt",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCovers_DbFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "DbFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPhoto",
                schema: "file",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorPhoto_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dt",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    BookCategoryId = table.Column<int>(nullable: true),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalSchema: "dt",
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dt",
                        principalTable: "Books",
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
                    { 2, "USA", "United States of America (the)" }
                });

            migrationBuilder.InsertData(
                schema: "srv",
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
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
                name: "IX_Authors_BookId",
                schema: "dt",
                table: "Authors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_BookId",
                schema: "dt",
                table: "BookCategories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_BookId",
                schema: "dt",
                table: "BookRatings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_SiteId",
                schema: "dt",
                table: "BookRatings",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CityId",
                schema: "dt",
                table: "Books",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                schema: "dt",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishingHouseId",
                schema: "dt",
                table: "Books",
                column: "PublishingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BookCategoryId",
                schema: "dt",
                table: "Notes",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BookId",
                schema: "dt",
                table: "Notes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_MainPageLinkId",
                schema: "dt",
                table: "Sites",
                column: "MainPageLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPhoto_AuthorId",
                schema: "file",
                table: "AuthorPhoto",
                column: "AuthorId");

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
            @"
	            ALTER DATABASE LDS  
	            SET FILESTREAM ( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'FilesStore' );  
	            GO  

	            ALTER DATABASE LDS
	            ADD FILEGROUP fsGroup CONTAINS FILESTREAM;
	            GO

	            ALTER DATABASE LDS
	            ADD FILE
	              ( NAME = 'fsLdsDB', FILENAME = 'D:\FileStorage'
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
                name: "BookRatings",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "Notes",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "AuthorPhoto",
                schema: "file");

            migrationBuilder.DropTable(
                name: "BookCovers",
                schema: "file");

            migrationBuilder.DropTable(
                name: "Sites",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "BookCategories",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "DbFiles");

            migrationBuilder.DropTable(
                name: "Links",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "srv");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "srv");

            migrationBuilder.DropTable(
                name: "PublishingHouses",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "srv");
        }
    }
}
