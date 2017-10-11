using Sistemas.Datos.Repositorios;
using Sistemas.Dtos.Shared;
using Sistemas.Dtos.Sitio;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Servicios.Sitio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Sitio
{
    public class ResenaService : IResenaService
    {
        private readonly IResenaRepository _resenaRepository;

        public ResenaService()
        {
            _resenaRepository = new ResenaRepository();
        }

        public void Guardar(ResenaDto resenaDto)
        {
            if (resenaDto.Estado == EstadoObjeto.Nuevo)
            {
                ResenaEntity resena = ResenaEntity.Crear(resenaDto.IdTipoResena, resenaDto.IdAutorResena, resenaDto.Titulo
                    , resenaDto.Subtitulo, resenaDto.Resumen, resenaDto.Resena, resenaDto.Recurso, resenaDto.Usuario);

                resena.ValidarObligatorios();

                _resenaRepository.Crear(resena);
            }
            else if (resenaDto.Estado == EstadoObjeto.Modificado)
            {
                ResenaEntity resena = _resenaRepository.Buscar(resenaDto.Id);
                resena.Modificar(resenaDto.IdTipoResena, resenaDto.IdAutorResena, resenaDto.Titulo
                    , resenaDto.Subtitulo, resenaDto.Resumen, resenaDto.Resena, resenaDto.Recurso, resenaDto.Usuario);
                _resenaRepository.Modificar();
            }
            else if (resenaDto.Estado == EstadoObjeto.Borrado)
            {
                _resenaRepository.Eliminar(resenaDto.Id);
            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<ResenaDto> ObtenerPorTipo(string idTipoResena)
        {
            ICollection<ResenaEntity> resenas = _resenaRepository.ObtenerPorTipo(idTipoResena);

            List<ResenaDto> resenasDto = resenas.Select(p => MapearResena(p)).ToList();

            return resenasDto;
        }

        public IList<ResenaDto> ObtenerTodo()
        {
            ICollection<ResenaEntity> resenas = _resenaRepository.ObtenerTodo();

            List<ResenaDto> resenasDto = resenas.Select(p => MapearResena(p)).ToList();

            return resenasDto;
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
