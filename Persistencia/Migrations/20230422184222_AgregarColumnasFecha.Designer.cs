﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(SeriesOnlineContext))]
    [Migration("20230422184222_AgregarColumnasFecha")]
    partial class AgregarColumnasFecha
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entidades.Capitulo", b =>
                {
                    b.Property<Guid>("CapituloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CapituloUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fechacreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCapitulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroCapitulo")
                        .HasColumnType("int");

                    b.Property<Guid?>("SerieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Temporada")
                        .HasColumnType("int");

                    b.Property<string>("imagenurl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CapituloId");

                    b.HasIndex("SerieId");

                    b.ToTable("Capitulo");
                });

            modelBuilder.Entity("Dominio.Entidades.Comentario", b =>
                {
                    b.Property<Guid>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CapituloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ComentarioTexto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fechacreacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SerieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ComentarioId");

                    b.HasIndex("CapituloId");

                    b.HasIndex("SerieId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Dominio.Entidades.Genero", b =>
                {
                    b.Property<Guid>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Fechacreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneroId");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            GeneroId = new Guid("2f724ecd-37fa-4eee-a978-cf5ee9ca2766"),
                            Nombre = "Animación"
                        },
                        new
                        {
                            GeneroId = new Guid("9512c75e-007d-4515-bc8e-77d61fd6dc59"),
                            Nombre = "Comedia"
                        },
                        new
                        {
                            GeneroId = new Guid("daafd0e7-d91f-446e-800d-5ec285a8b324"),
                            Nombre = "Romance"
                        },
                        new
                        {
                            GeneroId = new Guid("617e8ec5-af0d-4b59-99ab-6e6bcce00b67"),
                            Nombre = "Ciencia Ficción"
                        },
                        new
                        {
                            GeneroId = new Guid("86607794-9b5a-4eb2-89a1-3f93968b3023"),
                            Nombre = "Drama"
                        },
                        new
                        {
                            GeneroId = new Guid("5f2cb0eb-6f2f-45eb-86ce-a650e8bfc957"),
                            Nombre = "Aventura"
                        },
                        new
                        {
                            GeneroId = new Guid("50620894-a1ce-4708-87d4-480c6c0b300b"),
                            Nombre = "Acción"
                        },
                        new
                        {
                            GeneroId = new Guid("3203029e-78e0-4677-919a-d1231fd3c10b"),
                            Nombre = "Terror"
                        },
                        new
                        {
                            GeneroId = new Guid("653cc5db-e82c-465d-a21a-1200f71900d1"),
                            Nombre = "Erotismo"
                        },
                        new
                        {
                            GeneroId = new Guid("88d5d908-c8cf-41ca-96cf-00d6548374ec"),
                            Nombre = "Belico"
                        },
                        new
                        {
                            GeneroId = new Guid("1989aa58-4cf3-4531-ab69-4ab0d3ca6915"),
                            Nombre = "Super Heroes"
                        },
                        new
                        {
                            GeneroId = new Guid("5050f6ba-3f7b-46d0-be8a-079eb2c26dde"),
                            Nombre = "Corte Oscuro"
                        },
                        new
                        {
                            GeneroId = new Guid("c189f7dd-7b23-4cbf-8e34-95c933f2a046"),
                            Nombre = "Recuentos de vida"
                        },
                        new
                        {
                            GeneroId = new Guid("b6a4c370-7b84-4cde-8265-e15e8cfe2ad9"),
                            Nombre = "Escolar"
                        });
                });

            modelBuilder.Entity("Dominio.Entidades.GeneroSerie", b =>
                {
                    b.Property<Guid>("SerieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GeneroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SerieId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("GeneroSerie");
                });

            modelBuilder.Entity("Dominio.Entidades.Serie", b =>
                {
                    b.Property<Guid>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fechacreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerieId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("Dominio.Entidades.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.UsuarioSerie", b =>
                {
                    b.Property<Guid>("SerieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SerieId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioSerie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Capitulo", b =>
                {
                    b.HasOne("Dominio.Entidades.Serie", "serie")
                        .WithMany("NumeroCapitulo")
                        .HasForeignKey("SerieId");

                    b.Navigation("serie");
                });

            modelBuilder.Entity("Dominio.Entidades.Comentario", b =>
                {
                    b.HasOne("Dominio.Entidades.Capitulo", "capitulo")
                        .WithMany("TextoComentario")
                        .HasForeignKey("CapituloId");

                    b.HasOne("Dominio.Entidades.Serie", "serie")
                        .WithMany("TextoComentario")
                        .HasForeignKey("SerieId");

                    b.HasOne("Dominio.Entidades.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("capitulo");

                    b.Navigation("serie");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Dominio.Entidades.GeneroSerie", b =>
                {
                    b.HasOne("Dominio.Entidades.Genero", "genero")
                        .WithMany("Generoserie")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Serie", "serie")
                        .WithMany("Generoserie")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("genero");

                    b.Navigation("serie");
                });

            modelBuilder.Entity("Dominio.Entidades.UsuarioSerie", b =>
                {
                    b.HasOne("Dominio.Entidades.Serie", "serie")
                        .WithMany("UsuariodeSerie")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Usuario", "usuario")
                        .WithMany("UsuariodeSerie")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("serie");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dominio.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dominio.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dominio.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Capitulo", b =>
                {
                    b.Navigation("TextoComentario");
                });

            modelBuilder.Entity("Dominio.Entidades.Genero", b =>
                {
                    b.Navigation("Generoserie");
                });

            modelBuilder.Entity("Dominio.Entidades.Serie", b =>
                {
                    b.Navigation("Generoserie");

                    b.Navigation("NumeroCapitulo");

                    b.Navigation("TextoComentario");

                    b.Navigation("UsuariodeSerie");
                });

            modelBuilder.Entity("Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("UsuariodeSerie");
                });
#pragma warning restore 612, 618
        }
    }
}
