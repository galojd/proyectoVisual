using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Serie
    {
        public Guid SerieId{get;set;}
        public string? Nombre{get;set;}

        public string? Descripcion{get;set;}
        public string? Imagen{get;set;}

        public DateTime? Fechacreacion{get;set;}
        public ICollection<Capitulo>? NumeroCapitulo{get;set;}
        public ICollection<Comentario>?  TextoComentario{get;set;}
        public ICollection<UsuarioSerie>? UsuariodeSerie{get;set;}

        public ICollection<GeneroSerie>?  Generoserie{get;set;}

    }
}