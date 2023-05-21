using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class SeriesOnlineContext : IdentityDbContext<Usuario>
    {
        public SeriesOnlineContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //esto lo creo para las migraciones de tablas
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Comentario>().HasKey(ci => new{ci.Codigoserie, ci.Id, ci.CodigoCapitulo});
            modelBuilder.Entity<UsuarioSerie>().HasKey(ci => new{ci.SerieId, ci.UsuarioId});
            modelBuilder.Entity<GeneroSerie>().HasKey(ci => new{ci.SerieId, ci.GeneroId});
            //modelBuilder.Entity<Capitulo>().HasKey(ci => new{ci.Codigoserie, ci.CodigoCapitulo});
            modelBuilder.ApplyConfiguration(new UserSeed());
            
        }

        public DbSet<Comentario>? Comentario{get;set;}
        public DbSet<Capitulo>? Capitulo{get;set;} 
        public DbSet<Serie>? Serie{get;set;}
        public DbSet<Genero>? Genero{get;set;}
        public DbSet<UsuarioSerie>? UsuarioSerie{get;set;}
        public DbSet<GeneroSerie>? GeneroSerie{get;set;}

        public DbSet<Usuario>? Usuario{get;set;}

    }
}