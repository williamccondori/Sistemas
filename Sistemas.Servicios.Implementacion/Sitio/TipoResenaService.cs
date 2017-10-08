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
    public class TipoResenaService : ITipoResenaService
    {
        private readonly ITipoResenaRepository _tipoResenaRepository;

        public TipoResenaService()
        {
            _tipoResenaRepository = new TipoResenaRepository();
        }

        public void Guardar(TipoResenaDto tipoResenaDto)
        {
            if (tipoResenaDto.Estado == EstadoObjeto.Nuevo)
            {
                TipoResenaEntity tipoResena = TipoResenaEntity.Crear(tipoResenaDto.Id
                    , tipoResenaDto.Descripcion, tipoResenaDto.Usuario);

                _tipoResenaRepository.Crear(tipoResena);
            }
            else if (tipoResenaDto.Estado == EstadoObjeto.Modificado)
            {
                TipoResenaEntity tipoResena = _tipoResenaRepository.Buscar(tipoResenaDto.Id);
                tipoResena.Modificar(tipoResenaDto.Descripcion, tipoResenaDto.Usuario);
                _tipoResenaRepository.Modificar();
            }
            else if (tipoResenaDto.Estado == EstadoObjeto.Borrado)
            {
                _tipoResenaRepository.Eliminar(tipoResenaDto.Id);
            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<TipoResenaDto> ObtenerTodo()
        {
            ICollection<TipoResenaEntity> tiposResena = _tipoResenaRepository.ObtenerTodo();

            List<TipoResenaDto> tiposResenaDto = tiposResena.Select(p => new TipoResenaDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro,

                Descripcion = p.DescripcionTipoResena,
                Id = p.IdTipoResena
            }).ToList();

            return tiposResenaDto;
        }
    }
}
