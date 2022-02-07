﻿// <auto-generated />
using System;
using Challenge.Backend.AccessData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Challenge.Backend.AccessData.Migrations
{
    [DbContext(typeof(DisneyDbContext))]
    [Migration("20220207040756_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            Age = 25,
                            History = "Aladdín vive en una guarida en el bazar de Ágrabah con su mono Abú, y sueña con vivir lleno de lujos. Cuando conoce a Jasmín él no sabe que ella es la princesa, aunque él se enamora de ella. Cuando lo descubre, piensa que nunca conseguirá gustarle, pero un anciano (el cual es en realidad el Gran Visir Jafar), le ofrece el trato de conseguir todo tipo de fortunas con la ayuda de la Lámpara de la Cueva de las Maravillas, cuando Aladdín consigue la lámpara, el anciano le traiciona y le arroja a la cueva, pero Abú consiguió quitarle la Lámpara al anciano. Cuando Aladdín frota la lámpara, de ella aparece un Genio, el cual le concede tres deseos. Así que Aladdín desea que le convierta en príncipe.",
                            Image = "https://static.wikia.nocookie.net/disney/images/8/85/Aladdin_%28personaje%29.png/revision/latest/scale-to-width-down/358?cb=20160318010334&path-prefix=es",
                            Name = "Aladdin",
                            Weight = 85
                        },
                        new
                        {
                            CharacterId = 2,
                            Age = 100000,
                            History = "Genio es el tritagonista de la película Aladdín. Es un Genio, un espíritu cómico, muy poderoso, que actúa como un sirviente de quien tiene la propiedad de la Lámpara Mágica en la que reside.",
                            Image = "https://static.wikia.nocookie.net/disney/images/3/3a/20200401_135153.jpg/revision/latest/scale-to-width-down/1000?cb=20200401115358&path-prefix=es",
                            Name = "Genio",
                            Weight = 100
                        },
                        new
                        {
                            CharacterId = 3,
                            Age = 10,
                            History = " Hijo de Mufasa y Sarabi, Simba fue el siguiente a su padre en la línea para gobernar las Tierras del Reino. Sin embargo, después de que su malvado tío Scar asesinó a Mufasa y culpó a Simba por la muerte del antiguo rey, el joven cachorro de león es condenado al exilio mientras que Scar gobierna como rey. Fue entonces cuando Simba regresó a las Tierras del Reino y reclamó su trono y lugar legítimo en el gran ciclo de la vida.",
                            Image = "https://static.wikia.nocookie.net/disney/images/9/95/Simba.png/revision/latest/scale-to-width-down/317?cb=20121008182056&path-prefix=es",
                            Name = "Simba",
                            Weight = 100
                        });
                });

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.CharacterMovieOrSerie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieOrSerieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterMovieOrSerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CharacterId", "MovieOrSerieId", "CharacterMovieOrSerieId");

                    b.HasIndex("MovieOrSerieId");

                    b.ToTable("CharacterMovieOrSeries");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieOrSerieId = 1,
                            CharacterMovieOrSerieId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieOrSerieId = 1,
                            CharacterMovieOrSerieId = 2
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieOrSerieId = 2,
                            CharacterMovieOrSerieId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieOrSerieId = 3,
                            CharacterMovieOrSerieId = 4
                        });
                });

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Image = "https://i0.wp.com/xn--oo-yjab.cl/wp-content/uploads/2013/11/wonderland-pais-de-las-maravillas-alicia.jpg?resize=662%2C326&ssl=1",
                            Name = "Fantasía"
                        },
                        new
                        {
                            GenreId = 2,
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3JtHmv6mxkhmizikfV1ywAgWQouCnjEyPmg&usqp=CAU",
                            Name = "Aventura"
                        });
                });

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.MovieOrSerie", b =>
                {
                    b.Property<int>("MovieOrSerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MovieOrSerieId");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieOrSerieId");

                    b.ToTable("MovieOrSeries");

                    b.HasData(
                        new
                        {
                            MovieOrSerieId = 1,
                            CreationDate = new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            Image = "https://static.wikia.nocookie.net/disney/images/3/32/Aladdin-ATKOT.png/revision/latest/scale-to-width-down/245?cb=20140721083213&path-prefix=es",
                            Rating = 4,
                            Title = "Aladdín y el Rey de los Ladrones "
                        },
                        new
                        {
                            MovieOrSerieId = 2,
                            CreationDate = new DateTime(1994, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            Image = "https://static.wikia.nocookie.net/disney/images/1/1a/Lion_king_ver5_xlg.jpg/revision/latest/scale-to-width-down/1000?cb=20160923051934&path-prefix=es",
                            Rating = 5,
                            Title = "El Rey León"
                        },
                        new
                        {
                            MovieOrSerieId = 3,
                            CreationDate = new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 2,
                            Image = "https://static.wikia.nocookie.net/disney/images/4/43/The_Lion_Guard_Logo.png/revision/latest/scale-to-width-down/360?cb=20160926192441&path-prefix=es",
                            Rating = 3,
                            Title = "La Guardia del León"
                        });
                });

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.CharacterMovieOrSerie", b =>
                {
                    b.HasOne("Challenge.Backend.Domain.Entities.Character", "CharacterNavigator")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge.Backend.Domain.Entities.MovieOrSerie", "MovieOrSerieNavigator")
                        .WithMany()
                        .HasForeignKey("MovieOrSerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterNavigator");

                    b.Navigation("MovieOrSerieNavigator");
                });

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.MovieOrSerie", b =>
                {
                    b.HasOne("Challenge.Backend.Domain.Entities.Genre", "GenreNavigator")
                        .WithMany("MovieOrSeriesNavigator")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenreNavigator");
                });

            modelBuilder.Entity("Challenge.Backend.Domain.Entities.Genre", b =>
                {
                    b.Navigation("MovieOrSeriesNavigator");
                });
#pragma warning restore 612, 618
        }
    }
}
