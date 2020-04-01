﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningDataStorage.DAL.Migrations
{
    public partial class InitialMigration : Migration
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
                name: "FileDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(nullable: false),
                    UpdatedTimestamp = table.Column<DateTime>(nullable: false),
                    ContentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
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
                    Name = table.Column<string>(maxLength: 100, nullable: false)
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
                name: "BookEditions",
                schema: "dt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    PublishingHouseId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    PagesCount = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(maxLength: 13, nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEditions_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "dt",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookEditions_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "srv",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookEditions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "srv",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookEditions_PublishingHouses_PublishingHouseId",
                        column: x => x.PublishingHouseId,
                        principalSchema: "dt",
                        principalTable: "PublishingHouses",
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
                    BookEditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalSchema: "dt",
                        principalTable: "BookEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookCovers",
                schema: "file",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(nullable: false),
                    BookEditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCovers_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalSchema: "dt",
                        principalTable: "BookEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookId",
                schema: "dt",
                table: "Authors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_BookId",
                schema: "dt",
                table: "BookEditions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_CityId",
                schema: "dt",
                table: "BookEditions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_LanguageId",
                schema: "dt",
                table: "BookEditions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEditions_PublishingHouseId",
                schema: "dt",
                table: "BookEditions",
                column: "PublishingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BookEditionId",
                schema: "dt",
                table: "Notes",
                column: "BookEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPhoto_AuthorId",
                schema: "file",
                table: "AuthorPhoto",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCovers_BookEditionId",
                schema: "file",
                table: "BookCovers",
                column: "BookEditionId",
                unique: true);

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

                CREATE TABLE BookCoversStore AS FileTable
                WITH
                (
                    FileTable_Directory = 'BookCovers',
                    FileTable_Collate_Filename = database_default
                );
            ", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDescriptions");

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
                name: "Authors",
                schema: "dt");

            migrationBuilder.DropTable(
                name: "BookEditions",
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