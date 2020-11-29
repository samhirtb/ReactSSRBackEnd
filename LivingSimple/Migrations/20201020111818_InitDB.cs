using System;
using System.Collections.Generic;
using LivingSimple.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivingSimple.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    postPreviewContent = table.Column<string>(nullable: true),
                    postContent = table.Column<string>(nullable: true),
                    numberOfComments = table.Column<int>(nullable: false),
                    imgURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });

            migrationBuilder.Sql(@"
                INSERT INTO Posts(date, title, postPreviewContent, postContent, numberOfComments, imgURL)
                VALUES
                ('2020-10-29 10:47:03.8416690', 'My Post 1', 'Preview Content of post 1', 'This is the content that will be displayed to the screen', 1, '/img1'),
                ('2020-10-29 10:47:03.8416690', 'My Post 2', 'Testing preview', 'This is the content that will be displayed to the screen for post 2', 1, NULL),
                ('2020-10-31 10:47:03.8416690', 'Post 3 is here', 'Preview Content of post 3', 'Full content here', 1, '/img3')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
