using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnauserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("1989aa58-4cf3-4531-ab69-4ab0d3ca6915"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("2f724ecd-37fa-4eee-a978-cf5ee9ca2766"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("3203029e-78e0-4677-919a-d1231fd3c10b"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("5050f6ba-3f7b-46d0-be8a-079eb2c26dde"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("50620894-a1ce-4708-87d4-480c6c0b300b"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("5f2cb0eb-6f2f-45eb-86ce-a650e8bfc957"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("617e8ec5-af0d-4b59-99ab-6e6bcce00b67"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("653cc5db-e82c-465d-a21a-1200f71900d1"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("86607794-9b5a-4eb2-89a1-3f93968b3023"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("88d5d908-c8cf-41ca-96cf-00d6548374ec"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("9512c75e-007d-4515-bc8e-77d61fd6dc59"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("b6a4c370-7b84-4cde-8265-e15e8cfe2ad9"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("c189f7dd-7b23-4cbf-8e34-95c933f2a046"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("daafd0e7-d91f-446e-800d-5ec285a8b324"));

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Comentario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "GeneroId", "Fechacreacion", "Nombre" },
                values: new object[,]
                {
                    { new Guid("026954bd-9448-41ab-86f4-d07a642510b6"), null, "Belico" },
                    { new Guid("2650673d-3970-4405-ac1c-ff4704017de6"), null, "Ciencia Ficción" },
                    { new Guid("29615e62-4f51-42c7-985a-fbb4741adee0"), null, "Acción" },
                    { new Guid("30bf9e0a-e532-49b6-807c-2accf9c9d3c5"), null, "Comedia" },
                    { new Guid("39705ce0-51a2-4d1d-ac5c-00a8739ec168"), null, "Aventura" },
                    { new Guid("427ffb97-2359-4da6-8b2a-c5bfa58bb0db"), null, "Drama" },
                    { new Guid("5bfd5a7a-b238-4c4c-858d-9919d5909511"), null, "Animación" },
                    { new Guid("62c4857f-96fe-4348-a38f-2d9dd43fc9bc"), null, "Erotismo" },
                    { new Guid("7d07a71a-183d-4589-b8e7-6b5cfd04aac9"), null, "Corte Oscuro" },
                    { new Guid("909c0ce7-a1c9-4115-a391-fb114cb9bf1f"), null, "Terror" },
                    { new Guid("a608a89c-2c12-4bee-b96e-04fe9022acce"), null, "Romance" },
                    { new Guid("e4feef42-45a9-4376-a556-131e51b7270a"), null, "Super Heroes" },
                    { new Guid("f0fd4d04-a675-4363-a7bb-40aa02bcdcfd"), null, "Escolar" },
                    { new Guid("fa2c0b3b-7b02-4119-82d2-8b4c4782d4a5"), null, "Recuentos de vida" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("026954bd-9448-41ab-86f4-d07a642510b6"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("2650673d-3970-4405-ac1c-ff4704017de6"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("29615e62-4f51-42c7-985a-fbb4741adee0"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("30bf9e0a-e532-49b6-807c-2accf9c9d3c5"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("39705ce0-51a2-4d1d-ac5c-00a8739ec168"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("427ffb97-2359-4da6-8b2a-c5bfa58bb0db"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("5bfd5a7a-b238-4c4c-858d-9919d5909511"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("62c4857f-96fe-4348-a38f-2d9dd43fc9bc"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("7d07a71a-183d-4589-b8e7-6b5cfd04aac9"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("909c0ce7-a1c9-4115-a391-fb114cb9bf1f"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("a608a89c-2c12-4bee-b96e-04fe9022acce"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("e4feef42-45a9-4376-a556-131e51b7270a"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("f0fd4d04-a675-4363-a7bb-40aa02bcdcfd"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("fa2c0b3b-7b02-4119-82d2-8b4c4782d4a5"));

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Comentario");

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "GeneroId", "Fechacreacion", "Nombre" },
                values: new object[,]
                {
                    { new Guid("1989aa58-4cf3-4531-ab69-4ab0d3ca6915"), null, "Super Heroes" },
                    { new Guid("2f724ecd-37fa-4eee-a978-cf5ee9ca2766"), null, "Animación" },
                    { new Guid("3203029e-78e0-4677-919a-d1231fd3c10b"), null, "Terror" },
                    { new Guid("5050f6ba-3f7b-46d0-be8a-079eb2c26dde"), null, "Corte Oscuro" },
                    { new Guid("50620894-a1ce-4708-87d4-480c6c0b300b"), null, "Acción" },
                    { new Guid("5f2cb0eb-6f2f-45eb-86ce-a650e8bfc957"), null, "Aventura" },
                    { new Guid("617e8ec5-af0d-4b59-99ab-6e6bcce00b67"), null, "Ciencia Ficción" },
                    { new Guid("653cc5db-e82c-465d-a21a-1200f71900d1"), null, "Erotismo" },
                    { new Guid("86607794-9b5a-4eb2-89a1-3f93968b3023"), null, "Drama" },
                    { new Guid("88d5d908-c8cf-41ca-96cf-00d6548374ec"), null, "Belico" },
                    { new Guid("9512c75e-007d-4515-bc8e-77d61fd6dc59"), null, "Comedia" },
                    { new Guid("b6a4c370-7b84-4cde-8265-e15e8cfe2ad9"), null, "Escolar" },
                    { new Guid("c189f7dd-7b23-4cbf-8e34-95c933f2a046"), null, "Recuentos de vida" },
                    { new Guid("daafd0e7-d91f-446e-800d-5ec285a8b324"), null, "Romance" }
                });
        }
    }
}
