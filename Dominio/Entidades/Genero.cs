using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Genero
    {
        public Guid GeneroId{get;set;}
        public string? Nombre{get;set;}

        public DateTime? Fechacreacion{get;set;}

        public ICollection<GeneroSerie>?  Generoserie{get;set;}
    }
}