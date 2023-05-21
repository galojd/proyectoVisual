using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class UsuarioSerie
    {
        public Guid SerieId{get;set;}
        public string UsuarioId{get;set;}

        public Usuario? usuario{get;set;}
        public Serie? serie{get;set;}


    }
}