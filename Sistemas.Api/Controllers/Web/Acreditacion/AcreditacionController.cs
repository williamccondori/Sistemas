﻿using Sistemas.Api.Controllers.Base;
using Sistemas.Dtos.Http;
using Sistemas.Dtos.Sitio;
using Sistemas.Servicios.Implementacion.Web;
using Sistemas.Servicios.Web;
using System.Web.Http;

namespace Sistemas.Api.Controllers.Web.Nosotros
{
    [RoutePrefix("api/acreditacion")]
    public class AcreditacionController : BaseController
    {
        private IResenaService _resenaService;

        private const string _acreditacion = "AC";

        [Route(Predeterminado)]
        [HttpGet]
        public Response<ResenaDto> ObtenerXTipo()
        {
            return Ejecutar(() =>
            {
                _resenaService = new ResenaService();

                ResenaDto acreditacion = _resenaService.BuscarXTipo(_acreditacion);

                return Response<ResenaDto>.Correcto(acreditacion);
            });
        }
    }
}