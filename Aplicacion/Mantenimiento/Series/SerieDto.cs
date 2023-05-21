using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Capitulos;
using Aplicacion.Mantenimiento.Comentarios;
using Aplicacion.Mantenimiento.Generos;
using Aplicacion.Mantenimiento.GeneroSeries;
using Dominio.Entidades;

namespace Aplicacion.Mantenimiento.Series
{
    public class SerieDto
    {
        public Guid SerieId{get;set;}
        public string? Nombre{get;set;}

        public string? Descripcion{get;set;}
        public string? Imagen{get;set;}

        public ICollection<CapituloDto>? Capitulo{get;set;}
        public ICollection<ComentarioDto>?  TextoComentario{get;set;}
        
        public ICollection<GeneroDto>?  Generoserie1{get;set;}
    }
}