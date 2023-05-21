using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class GeneroSerie
    {
        public Guid GeneroId{get;set;}
        public Guid SerieId{get;set;}

        public Serie? serie{get;set;}
        public Genero? genero{get;set;}
    }
}