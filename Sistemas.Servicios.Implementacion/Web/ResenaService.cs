using Sistemas.Datos.Repositorios;
using Sistemas.Dtos.Shared;
using Sistemas.Dtos.Sitio;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Servicios.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Web
{
    public class ResenaService : IResenaService
    {
        private readonly IResenaRepository _resenaRepository;

        public ResenaService()
        {
            _resenaRepository = new ResenaRepository();
        }

        public ResenaDto BuscarXTipo(string idTipoResena)
        {
            ICollection<ResenaEntity> resenas = _resenaRepository.ObtenerPorTipo(idTipoResena);

            List<ResenaDto> resenasDto = resenas.Select(p => MapearResena(p)).ToList();

            ResenaDto resenaDto = resenasDto.FirstOrDefault();

            if (resenaDto == null)
            {
                throw new Exception();
            }

            return resenaDto;
        }

        private ResenaDto MapearResena(ResenaEntity resena)
        {
            AutorResenaEntity autorResena = resena.ObtenerAutor();
            TipoResenaEntity tipoResena = resena.ObtenerTipo();

            ResenaDto resenaDto = new ResenaDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = resena.FechaModifico ?? resena.FechaRegistro,
                Usuario = resena.UsuarioModifico ?? resena.UsuarioRegistro,
                Id = resena.IdResena,
                IdTipoResena = resena.IdTipoResena,
                AutorResena = new AutorResenaDto
                {
                    Id = autorResena.IdAutorResena,
                    Nombre = autorResena.DescripcionNombre,
                    Apellido = autorResena.DescripcionApellido
                },
                Recurso = resena.DescripcionRecurso,
                Resena = resena.DescripcionResena,
                Resumen = resena.DescripcionResumen,
                Subtitulo = resena.DescripcionSubtitulo,
                IdAutorResena = resena.IdAutorResena,
                Titulo = resena.DescripcionTitulo,
                TipoResena = new TipoResenaDto
                {
                    Id = tipoResena.IdTipoResena,
                    Descripcion = tipoResena.DescripcionTipoResena
                }
            };

            return resenaDto;
        }
    }
}
