using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnasFecha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("10c38c0a-5620-4f00-b950-4263ebf215fb"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("1b77047c-c526-4b0c-a3d2-4158c6e0d735"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("3f6f9ff4-c6ae-4e99-81e0-c6fd20088416"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("5b795113-0407-4d8f-9c21-e44af90a7916"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("64636a50-2147-423c-a25d-41f834331d4c"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("778136f3-c81b-4896-a4f0-e7914520df74"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("88269cee-0b30-4ce7-a2a9-5a5f1e1b50d7"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("8e3742db-a23a-4591-ad03-f56d503d6afe"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("9e026de0-57d6-409a-90ae-fc4dc174e56e"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("b97f5ec1-ce3f-49c0-9d53-b85ae622de7a"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("c91e22ac-666e-4650-b592-47be6feb999b"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("e219975a-b961-4e47-b291-15a921899dcf"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("f866e457-b52f-4912-a941-e33b0b41af8d"));

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "GeneroId",
                keyValue: new Guid("f945714c-3bd7-48cc-86ae-44e6d6731382"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechacreacion",
                table: "Serie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechacreacion",
                table: "Genero",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechacreacion",
                table: "Comentario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechacreacion",
                table: "Capitulo",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Fechacreacion",
                table: "Serie");

            migrationBuilder.DropColumn(
                name: "Fechacreacion",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "Fechacreacion",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "Fechacreacion",
                table: "Capitulo");

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { new Guid("10c38c0a-5620-4f00-b950-4263ebf215fb"), "Recuentos de vida" },
                    { new Guid("1b77047c-c526-4b0c-a3d2-4158c6e0d735"), "Corte Oscuro" },
                    { new Guid("3f6f9ff4-c6ae-4e99-81e0-c6fd20088416"), "Ciencia Ficción" },
                    { new Guid("5b795113-0407-4d8f-9c21-e44af90a7916"), "Animación" },
                    { new Guid("64636a50-2147-423c-a25d-41f834331d4c"), "Romance" },
                    { new Guid("778136f3-c81b-4896-a4f0-e7914520df74"), "Drama" },
                    { new Guid("88269cee-0b30-4ce7-a2a9-5a5f1e1b50d7"), "Erotismo" },
                    { new Guid("8e3742db-a23a-4591-ad03-f56d503d6afe"), "Super Heroes" },
                    { new Guid("9e026de0-57d6-409a-90ae-fc4dc174e56e"), "Belico" },
                    { new Guid("b97f5ec1-ce3f-49c0-9d53-b85ae622de7a"), "Aventura" },
                    { new Guid("c91e22ac-666e-4650-b592-47be6feb999b"), "Acción" },
                    { new Guid("e219975a-b961-4e47-b291-15a921899dcf"), "Comedia" },
                    { new Guid("f866e457-b52f-4912-a941-e33b0b41af8d"), "Terror" },
                    { new Guid("f945714c-3bd7-48cc-86ae-44e6d6731382"), "Escolar" }
                });
        }
    }
}
