using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Capitulo
    {
        public Guid CapituloId{get;set;}
        public int? NumeroCapitulo{get;set;}
        public string? NombreCapitulo{get;set;}
        public string? CapituloUrl{get;set;}
        public string? imagenurl{get;set;}
        public Guid? SerieId{get;set;}
        public int? Temporada{get;set;}

        public DateTime? Fechacreacion{get;set;}

        public ICollection<Comentario>?  TextoComentario{get;set;}

        public Serie? serie{get;set;}
        
    }
}