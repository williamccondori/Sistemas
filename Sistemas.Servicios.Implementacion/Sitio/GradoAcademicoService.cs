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
    public class GradoAcademicoService : IGradoAcademicoService
    {
        private readonly IGradoAcademicoRepository _gradoAcademicoRepository;

        public GradoAcademicoService()
        {
            _gradoAcademicoRepository = new GradoAcademicoRepository();
        }

        public void Guardar(GradoAcademicoDto gradoAcademicoDto)
        {
            if (gradoAcademicoDto.Estado == EstadoObjeto.Nuevo)
            {
                GradoAcademicoEntity gradoAcademico = GradoAcademicoEntity.Crear(gradoAcademicoDto.Titulo
                    , gradoAcademicoDto.Abreviatura, gradoAcademicoDto.Usuario);

                _gradoAcademicoRepository.Crear(gradoAcademico);
            }
            else if (gradoAcademicoDto.Estado == EstadoObjeto.Modificado)
            {

            }
            else if (gradoAcademicoDto.Estado == EstadoObjeto.Borrado)
            {

            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<GradoAcademicoDto> ObtenerTodo()
        {
            ICollection<GradoAcademicoEntity> gradosAcademicos = _gradoAcademicoRepository.ObtenerTodo();

            List<GradoAcademicoDto> gradosAcademicosDto = gradosAcademicos.Select(p => new GradoAcademicoDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro,
                Id = p.IdGradoAcademico,
                Titulo = p.DescripcionTitulo,
                Abreviatura = p.DescripcionAbreviatura
            }).ToList();

            return gradosAcademicosDto;
        }
    }
}
