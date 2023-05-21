using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Capitulos;
using Aplicacion.Mantenimiento.Comentarios;
using Aplicacion.Mantenimiento.Generos;
using Aplicacion.Mantenimiento.GeneroSeries;
using Aplicacion.Mantenimiento.Series;
using Aplicacion.Mantenimiento.UsuarioSeries;
using Aplicacion.Seguridad;
using AutoMapper;
using Dominio.Entidades;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Serie, SerieDto>()
            .ForMember(x => x.Generoserie1, y => y.MapFrom(z => z.Generoserie!.Select(a => a.genero).ToList()))
            .ForMember(x => x.Capitulo, y => y.MapFrom(z => z.NumeroCapitulo))
            .ForMember(x => x.TextoComentario, y => y.MapFrom(z => z.TextoComentario));

            CreateMap<UsuarioSerie,UsuarioSerieDto>();

            CreateMap<GeneroSerie, GeneroSerieDto>();

            CreateMap<Comentario, ComentarioDto>();

            CreateMap<Capitulo, CapituloDto>()
            .ForMember(x => x.TextoComentario, y => y.MapFrom(z => z.TextoComentario));

            CreateMap<Genero, GeneroDto>();

            CreateMap<Usuario, UsuarioDto>()
            .ForMember(x => x.UsuariodeSerie, y => y.MapFrom(z => z.UsuariodeSerie!.Select(a => a.serie).ToList()));
        }
    }
}