using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Mantenimiento.Comentarios
{
    public class ComentarioDto
    {
        public Guid ComentarioId { get; set; }

        public string? ComentarioTexto { get; set; }
        public string? UsuarioId { get; set; }
        public Guid? SerieId { get; set; }
        public Guid? CapituloId { get; set; }
    }
}