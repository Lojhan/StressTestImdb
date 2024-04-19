using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StressTestImdb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "imdb");

            migrationBuilder.CreateTable(
                name: "namebasics",
                schema: "imdb",
                columns: table => new
                {
                    nconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    primaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthYear = table.Column<int>(type: "int", nullable: false),
                    deathYear = table.Column<int>(type: "int", nullable: false),
                    primaryProfession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    knownForTitles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_namebasics", x => x.nconst);
                });

            migrationBuilder.CreateTable(
                name: "titlebasics",
                schema: "imdb",
                columns: table => new
                {
                    tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    titleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    originalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAdult = table.Column<bool>(type: "bit", nullable: false),
                    startYear = table.Column<int>(type: "int", nullable: false),
                    endYear = table.Column<int>(type: "int", nullable: false),
                    runtimeMinutes = table.Column<int>(type: "int", nullable: false),
                    genres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titlebasics", x => x.tconst);
                });

            migrationBuilder.CreateTable(
                name: "titlecrew",
                schema: "imdb",
                columns: table => new
                {
                    tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    directors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    writers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titlecrew", x => x.tconst);
                });

            migrationBuilder.CreateTable(
                name: "titleakas",
                schema: "imdb",
                columns: table => new
                {
                    titleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    types = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isOriginalTitle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titleakas", x => x.titleId);
                    table.ForeignKey(
                        name: "FK_titleakas_titlebasics_titleId",
                        column: x => x.titleId,
                        principalSchema: "imdb",
                        principalTable: "titlebasics",
                        principalColumn: "tconst",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_titleakas_titlecrew_titleId",
                        column: x => x.titleId,
                        principalSchema: "imdb",
                        principalTable: "titlecrew",
                        principalColumn: "tconst",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titleepisode",
                schema: "imdb",
                columns: table => new
                {
                    tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    parentTconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    seasonNumber = table.Column<int>(type: "int", nullable: false),
                    episodeNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titleepisode", x => x.tconst);
                    table.ForeignKey(
                        name: "FK_titleepisode_titleakas_parentTconst",
                        column: x => x.parentTconst,
                        principalSchema: "imdb",
                        principalTable: "titleakas",
                        principalColumn: "titleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titleprincipals",
                schema: "imdb",
                columns: table => new
                {
                    tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    nconst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characters = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titleprincipals", x => x.tconst);
                    table.ForeignKey(
                        name: "FK_titleprincipals_titleakas_tconst",
                        column: x => x.tconst,
                        principalSchema: "imdb",
                        principalTable: "titleakas",
                        principalColumn: "titleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titleratings",
                schema: "imdb",
                columns: table => new
                {
                    tconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    averageRating = table.Column<double>(type: "float", nullable: false),
                    numVotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titleratings", x => x.tconst);
                    table.ForeignKey(
                        name: "FK_titleratings_titleakas_tconst",
                        column: x => x.tconst,
                        principalSchema: "imdb",
                        principalTable: "titleakas",
                        principalColumn: "titleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_titleepisode_parentTconst",
                schema: "imdb",
                table: "titleepisode",
                column: "parentTconst");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "namebasics",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "titleepisode",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "titleprincipals",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "titleratings",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "titleakas",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "titlebasics",
                schema: "imdb");

            migrationBuilder.DropTable(
                name: "titlecrew",
                schema: "imdb");
        }
    }
}
