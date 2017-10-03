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
    public class AutorResenaService : IAutorResenaService
    {
        private readonly IAutorResenaRepository _autorResenaRepository;

        public AutorResenaService()
        {
            _autorResenaRepository = new AutorResenaRepository();
        }

        public void Guardar(AutorResenaDto autorResenaDto)
        {
            if (autorResenaDto.Estado == EstadoObjeto.Nuevo)
            {
                AutorResenaEntity autorResena = AutorResenaEntity.Crear(autorResenaDto.IdGradoAcademico, autorResenaDto.Nombre
                    , autorResenaDto.Apellido, autorResenaDto.Cargo, autorResenaDto.Recurso, autorResenaDto.Usuario);

                _autorResenaRepository.Crear(autorResena);
            }
            else if (autorResenaDto.Estado == EstadoObjeto.Modificado)
            {

            }
            else if (autorResenaDto.Estado == EstadoObjeto.Borrado)
            {

            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<AutorResenaDto> ObtenerTodo()
        {
            ICollection<AutorResenaEntity> autoresResena = _autorResenaRepository.ObtenerTodo();

            List<AutorResenaDto> autoresResenaDto = autoresResena.Select(p => new AutorResenaDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro,

                Id = p.IdAutorResena,
                Apellido = p.DescripcionApellido,
                Cargo = p.DescripcionCargo,
                IdGradoAcademico = p.IdGradoAcademico,
                Nombre = p.DescripcionNombre,
                Recurso = p.DescripcionRecurso,

                GradoAcademico = new GradoAcademicoDto
                {
                    Abreviatura = p.GradoAcademicoX.DescripcionAbreviatura,
                    Titulo = p.GradoAcademicoX.DescripcionTitulo,
                    Id = p.GradoAcademicoX.IdGradoAcademico
                }
            }).ToList();

            return autoresResenaDto;
        }
    }
}
