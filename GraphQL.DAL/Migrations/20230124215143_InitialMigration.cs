using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQL.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProject",
                columns: table => new
                {
                    DevelopersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProject", x => new { x.DevelopersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_DeveloperProject_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProjectItem",
                columns: table => new
                {
                    DevelopersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProjectItem", x => new { x.DevelopersId, x.ProjectItemsId });
                    table.ForeignKey(
                        name: "FK_DeveloperProjectItem_Developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProjectItem_ProjectItems_ProjectItemsId",
                        column: x => x.ProjectItemsId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProject_ProjectsId",
                table: "DeveloperProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProjectItem_ProjectItemsId",
                table: "DeveloperProjectItem",
                column: "ProjectItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectId",
                table: "ProjectItems",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperProject");

            migrationBuilder.DropTable(
                name: "DeveloperProjectItem");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
