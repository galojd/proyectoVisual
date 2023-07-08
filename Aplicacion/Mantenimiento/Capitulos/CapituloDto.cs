using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Comentarios;

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class CapituloDto
    {
        public Guid CapituloId { get; set; }
        public int? NumeroCapitulo { get; set; }
        public string? NombreCapitulo { get; set; }

        public string? Nombreserie{ get; set; }
        public string? CapituloUrl { get; set; }
        public string? imagenurl { get; set; }
        public Guid? SerieId { get; set; }
        public int? Temporada { get; set; }
        public ICollection<ComentarioDto>?  TextoComentario{get;set;}
    }
}