using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Blog");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Blog",
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "date", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "Blog",
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
              schema: "Blog",
              table: "Authors",
              columns: new[] { "Id", "Name", "Birthday" },
              values: new object[,]
              {
                  {1, "Igor", "9/24/1960" },
                  {2, "Vasya", "9/14/1966" },
                  {3, "Kolya", "3/24/2000" },
                  {4, "Petya", "9/11/1973" },
                  {5, "Sasha", "6/30/1981" },
              }
            );


            migrationBuilder.InsertData(
             schema: "Blog",
             table: "Posts",
             columns: new[] { "Id", "Title", "Text", "CreationDate", "AuthorId" },
             values: new object[,]
             {
                  {1, "IgorTitle1","Igor Text Text1", "9/24/2023",1 },
                  {2, "IgorTitle2","Igor Text Text2", "10/12/2022",1 },
                  {3, "IgorTitle3","Igor Text Text3", "11/20/2023",1 },
                  {4, "VasyaTitle1","Vasya text1" , "9/14/2015", 2 },
                  {5, "VasyaTitle2","Vasya text2" , "5/11/2021", 2 }
             }
           );

            migrationBuilder.InsertData(
            schema: "Blog",
            table: "Comments",
            columns: new[] { "Id", "Text", "CommentDate", "PostId" },
            values: new object[,]
            {
                  {1, "Igor comment 1", "9/24/2024",1 },
                  {2, "Igor comment 2", "9/25/2024",1 },
                  {3, "Vasya comment 1", "9/25/2024",4 },
            }
          );

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                schema: "Blog",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                schema: "Blog",
                table: "Posts",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "Blog");
        }
    }
}
