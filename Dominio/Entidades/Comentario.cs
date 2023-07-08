using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Comentario
    {
        public Guid ComentarioId { get; set; }

        public string? ComentarioTexto { get; set; }
        public string? UsuarioId { get; set; }

         public string? userName{get;set;}
        public Guid? SerieId { get; set; }
        public Guid? CapituloId { get; set; }

        public DateTime? Fechacreacion{get;set;}

        public Usuario? usuario{get;set;}
        public Serie? serie{get;set;}
        public Capitulo? capitulo{get;set;}
    }
}