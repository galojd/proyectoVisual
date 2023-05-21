using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Series;
using Dominio.Entidades;

namespace Aplicacion.Mantenimiento.UsuarioSeries
{
    public class UsuarioDto
    {
        public string? Id{get;set;}
        public string? NombreCompleto {get;set;}

        public string? Email{get;set;}

        public string? Username{get;set;}

        public string? Imagen{get;set;}

        public ICollection<SerieDto>? UsuariodeSerie{get;set;}
    }
}