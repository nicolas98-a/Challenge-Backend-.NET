using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Backend.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "MovieOrSeries",
                columns: table => new
                {
                    MovieOrSerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieOrSeries", x => x.MovieOrSerieId);
                    table.ForeignKey(
                        name: "FK_MovieOrSeries_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovieOrSeries",
                columns: table => new
                {
                    CharacterMovieOrSerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieOrSerieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovieOrSeries", x => new { x.CharacterId, x.MovieOrSerieId, x.CharacterMovieOrSerieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovieOrSeries_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovieOrSeries_MovieOrSeries_MovieOrSerieId",
                        column: x => x.MovieOrSerieId,
                        principalTable: "MovieOrSeries",
                        principalColumn: "MovieOrSerieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Age", "History", "Image", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 25, "Aladdín vive en una guarida en el bazar de Ágrabah con su mono Abú, y sueña con vivir lleno de lujos. Cuando conoce a Jasmín él no sabe que ella es la princesa, aunque él se enamora de ella. Cuando lo descubre, piensa que nunca conseguirá gustarle, pero un anciano (el cual es en realidad el Gran Visir Jafar), le ofrece el trato de conseguir todo tipo de fortunas con la ayuda de la Lámpara de la Cueva de las Maravillas, cuando Aladdín consigue la lámpara, el anciano le traiciona y le arroja a la cueva, pero Abú consiguió quitarle la Lámpara al anciano. Cuando Aladdín frota la lámpara, de ella aparece un Genio, el cual le concede tres deseos. Así que Aladdín desea que le convierta en príncipe.", "https://static.wikia.nocookie.net/disney/images/8/85/Aladdin_%28personaje%29.png/revision/latest/scale-to-width-down/358?cb=20160318010334&path-prefix=es", "Aladdin", 85 },
                    { 2, 100000, "Genio es el tritagonista de la película Aladdín. Es un Genio, un espíritu cómico, muy poderoso, que actúa como un sirviente de quien tiene la propiedad de la Lámpara Mágica en la que reside.", "https://static.wikia.nocookie.net/disney/images/3/3a/20200401_135153.jpg/revision/latest/scale-to-width-down/1000?cb=20200401115358&path-prefix=es", "Genio", 100 },
                    { 3, 10, " Hijo de Mufasa y Sarabi, Simba fue el siguiente a su padre en la línea para gobernar las Tierras del Reino. Sin embargo, después de que su malvado tío Scar asesinó a Mufasa y culpó a Simba por la muerte del antiguo rey, el joven cachorro de león es condenado al exilio mientras que Scar gobierna como rey. Fue entonces cuando Simba regresó a las Tierras del Reino y reclamó su trono y lugar legítimo en el gran ciclo de la vida.", "https://static.wikia.nocookie.net/disney/images/9/95/Simba.png/revision/latest/scale-to-width-down/317?cb=20121008182056&path-prefix=es", "Simba", 100 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "https://i0.wp.com/xn--oo-yjab.cl/wp-content/uploads/2013/11/wonderland-pais-de-las-maravillas-alicia.jpg?resize=662%2C326&ssl=1", "Fantasía" },
                    { 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3JtHmv6mxkhmizikfV1ywAgWQouCnjEyPmg&usqp=CAU", "Aventura" }
                });

            migrationBuilder.InsertData(
                table: "MovieOrSeries",
                columns: new[] { "MovieOrSerieId", "CreationDate", "GenreId", "Image", "Rating", "Title" },
                values: new object[] { 1, new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://static.wikia.nocookie.net/disney/images/3/32/Aladdin-ATKOT.png/revision/latest/scale-to-width-down/245?cb=20140721083213&path-prefix=es", 4, "Aladdín y el Rey de los Ladrones " });

            migrationBuilder.InsertData(
                table: "MovieOrSeries",
                columns: new[] { "MovieOrSerieId", "CreationDate", "GenreId", "Image", "Rating", "Title" },
                values: new object[] { 2, new DateTime(1994, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://static.wikia.nocookie.net/disney/images/1/1a/Lion_king_ver5_xlg.jpg/revision/latest/scale-to-width-down/1000?cb=20160923051934&path-prefix=es", 5, "El Rey León" });

            migrationBuilder.InsertData(
                table: "MovieOrSeries",
                columns: new[] { "MovieOrSerieId", "CreationDate", "GenreId", "Image", "Rating", "Title" },
                values: new object[] { 3, new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://static.wikia.nocookie.net/disney/images/4/43/The_Lion_Guard_Logo.png/revision/latest/scale-to-width-down/360?cb=20160926192441&path-prefix=es", 3, "La Guardia del León" });

            migrationBuilder.InsertData(
                table: "CharacterMovieOrSeries",
                columns: new[] { "CharacterId", "CharacterMovieOrSerieId", "MovieOrSerieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 3, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovieOrSeries_MovieOrSerieId",
                table: "CharacterMovieOrSeries",
                column: "MovieOrSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreId",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieOrSeries_GenreId",
                table: "MovieOrSeries",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieOrSeries_MovieOrSerieId",
                table: "MovieOrSeries",
                column: "MovieOrSerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovieOrSeries");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "MovieOrSeries");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
