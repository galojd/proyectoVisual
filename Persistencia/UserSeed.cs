using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia
{
    public class UserSeed : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.HasData(
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Animación" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Comedia" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Romance" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Ciencia Ficción" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Drama" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Aventura" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Acción" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Terror" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Erotismo" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Belico" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Super Heroes" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Corte Oscuro" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Recuentos de vida" },
            new Genero { GeneroId = Guid.NewGuid(), Nombre = "Escolar" }           
        );
    }
    }
}