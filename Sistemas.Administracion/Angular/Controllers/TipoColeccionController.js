(function (module) {

    TipoColeccionController.$inject = [
        '$scope',
        'alertify',
        'TipoPublicacionFactory',
        'TipoDetallePublicacionFactory',
        'TipoResenaFactory'
    ];

    function TipoColeccionController($scope, alertify, TipoPublicacionFactory, TipoDetallePublicacionFactory
        , TipoResenaFactory) {

        alertify
            .okBtn("Si")
            .cancelBtn("No");

        $scope.TiposPublicacion = [];
        $scope.TiposDetallePublicacion = [];
        $scope.TiposResena = [];

        $scope.Iniciar = function () {
            $scope.Formulario = EstadoFormulario.SinCambios;
            $scope.IniciarTipoPublicacion();
            $scope.IniciarTipoDetallePublicacion();
            $scope.IniciarTipoResena();
            $scope.ObtenerTiposPublicacion();
            $scope.ObtenerTiposDetallePublicacion();
            $scope.ObtenerTiposResena();
        };

        $scope.TextoBotonGuardar = function () {
            return $scope.Formulario === EstadoFormulario.Modificar ? 'Modificar' : 'Crear';
        };

        $scope.ModificarCodigo = function () {
            return $scope.Formulario === EstadoFormulario.Modificar;
        };

        /**
         * Tipos de publicación
         */

        $scope.IniciarTipoPublicacion = function (tipoPublicacion) {
            if (!tipoPublicacion) {
                $scope.TipoPublicacion = {
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.TipoPublicacion = tipoPublicacion;
            }
        };

        $scope.CrearTipoPublicacion = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarTipoPublicacion();
            $scope.TipoPublicacion.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalTipoPublicacion");
        };

        $scope.ModificarTipoPublicacion = function (tipoPublicacion) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarTipoPublicacion(tipoPublicacion);
            $scope.TipoPublicacion.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalTipoPublicacion");
        };

        $scope.EliminarTipoPublicacion = function (tipoPublicacion) {
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarTipoPublicacion(tipoPublicacion);
                $scope.TipoPublicacion.Estado = EstadoObjeto.Borrado;
                $scope.GuardarTipoPublicacion();
            });
        };

        $scope.CerrarTipoPublicacion = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalTipoPublicacion");
            });
        };

        $scope.GuardarTipoPublicacion = function () {
            Bootstrap.CerrarModal("#ModalTipoPublicacion");
            TipoPublicacionFactory.GuardarTipoPublicacion($scope.TipoPublicacion).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerTiposPublicacion();
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.ObtenerTiposPublicacion = function () {
            TipoPublicacionFactory.ObtenerTiposPublicacion().then(function (response) {
                if (response.Estado) {
                    $scope.TiposPublicacion = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        /**
         * Tipos de detalle de publicación
         */

        $scope.IniciarTipoDetallePublicacion = function (tipoDetallePublicacion) {
            if (!tipoDetallePublicacion) {
                $scope.TipoDetallePublicacion = {
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.TipoDetallePublicacion = tipoDetallePublicacion;
            }
        };

        $scope.CrearTipoDetallePublicacion = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarTipoDetallePublicacion();
            $scope.TipoDetallePublicacion.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalTipoDetallePublicacion");
        };

        $scope.ModificarTipoDetallePublicacion = function (tipoDetallePublicacion) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarTipoDetallePublicacion(tipoDetallePublicacion);
            $scope.TipoDetallePublicacion.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalTipoDetallePublicacion");
        };

        $scope.EliminarTipoDetallePublicacion = function (tipoDetallePublicacion) {
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarTipoDetallePublicacion(tipoDetallePublicacion);
                $scope.TipoDetallePublicacion.Estado = EstadoObjeto.Borrado;
                $scope.GuardarTipoDetallePublicacion();
            });
        };

        $scope.CerrarTipoDetallePublicacion = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalTipoDetallePublicacion");
            });
        };

        $scope.GuardarTipoDetallePublicacion = function () {
            Bootstrap.CerrarModal("#ModalTipoDetallePublicacion");
            TipoDetallePublicacionFactory.GuardarTipoDetallePublicacion($scope.TipoDetallePublicacion).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerTiposDetallePublicacion();
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.ObtenerTiposDetallePublicacion = function () {
            TipoDetallePublicacionFactory.ObtenerTiposDetallePublicacion().then(function (response) {
                if (response.Estado) {
                    $scope.TiposDetallePublicacion = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        /**
         * Tipos de reseña
         */

        $scope.IniciarTipoResena = function (tipoResena) {
            if (!tipoResena) {
                $scope.TipoResena = {
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.TipoResena = tipoResena;
            }
        };

        $scope.CrearTipoResena = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarTipoResena();
            $scope.TipoResena.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalTipoResena");
        };

        $scope.ModificarTipoResena = function (tipoResena) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarTipoResena(tipoResena);
            $scope.TipoResena.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalTipoResena");
        };

        $scope.EliminarTipoResena = function (tipoResena) {
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarTipoResena(tipoResena);
                $scope.TipoResena.Estado = EstadoObjeto.Borrado;
                $scope.GuardarTipoResena();
            });
        };

        $scope.CerrarTipoResena = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalTipoResena");
            });
        };

        $scope.GuardarTipoResena = function () {
            Bootstrap.CerrarModal("#ModalTipoResena");
            TipoResenaFactory.GuardarTipoResena($scope.TipoResena).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerTiposResena();
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.ObtenerTiposResena = function () {
            TipoResenaFactory.ObtenerTiposResena().then(function (response) {
                if (response.Estado) {
                    $scope.TiposResena = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };
    }

    module.controller('TipoColeccionController', TipoColeccionController);

})(angular.module('EpisApp'));