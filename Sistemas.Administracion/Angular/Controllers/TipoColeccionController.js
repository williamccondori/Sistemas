(function (module) {

    TipoColeccionController.$inject = [
        '$scope',
        'TipoPublicacionFactory',
        'TipoDetallePublicacionFactory',
        'TipoResenaFactory'
    ];

    function TipoColeccionController($scope, TipoPublicacionFactory, TipoDetallePublicacionFactory
        , TipoResenaFactory) {

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
            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarTipoPublicacion(tipoPublicacion);
            $scope.TipoPublicacion.Estado = EstadoObjeto.Borrado;
            $scope.GuardarPublicacion();
        };

        $scope.CerrarTipoPublicacion = function () {
            Bootstrap.CerrarModal("#ModalTipoPublicacion");
        };

        $scope.GuardarTipoPublicacion = function () {
            Bootstrap.CerrarModal("#ModalTipoPublicacion");
            TipoPublicacionFactory.GuardarTipoPublicacion($scope.TipoPublicacion).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerTiposPublicacion();
                } else {
                    console.log(response.Mensaje);
                }
            });
        };

        $scope.ObtenerTiposPublicacion = function () {
            TipoPublicacionFactory.ObtenerTiposPublicacion().then(function (response) {
                if (response.Estado) {
                    $scope.TiposPublicacion = response.Datos;
                } else {
                    console.log(response.Mensaje);
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
            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarTipoDetallePublicacion(tipoDetallePublicacion);
            $scope.TipoDetallePublicacion.Estado = EstadoObjeto.Borrado;
            $scope.GuardarDetallePublicacion();
        };

        $scope.CerrarTipoDetallePublicacion = function () {
            Bootstrap.CerrarModal("#ModalTipoDetallePublicacion");
        };

        $scope.GuardarTipoDetallePublicacion = function () {
            Bootstrap.CerrarModal("#ModalTipoDetallePublicacion");
            TipoDetallePublicacionFactory.GuardarTipoDetallePublicacion($scope.TipoDetallePublicacion).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerTiposDetallePublicacion();
                } else {
                    console.log(response.Mensaje);
                }
            });
        };

        $scope.ObtenerTiposDetallePublicacion = function () {
            TipoDetallePublicacionFactory.ObtenerTiposDetallePublicacion().then(function (response) {
                if (response.Estado) {
                    $scope.TiposDetallePublicacion = response.Datos;
                } else {
                    console.log(response.Mensaje);
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
            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarTipoResena(tipoResena);
            $scope.TipoResena.Estado = EstadoObjeto.Borrado;
            $scope.GuardarResena();
        };

        $scope.CerrarTipoResena = function () {
            Bootstrap.CerrarModal("#ModalTipoResena");
        };

        $scope.GuardarTipoResena = function () {
            Bootstrap.CerrarModal("#ModalTipoResena");
            $scope.TiposResena.push($scope.TipoResena);
        };

        $scope.GuardarTipoResena = function () {
            Bootstrap.CerrarModal("#ModalTipoResena");
            TipoResenaFactory.GuardarTipoResena($scope.TipoResena).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerTiposResena();
                } else {
                    console.log(response.Mensaje);
                }
            });
        };

        $scope.ObtenerTiposResena = function () {
            TipoResenaFactory.ObtenerTiposResena().then(function (response) {
                if (response.Estado) {
                    $scope.TiposResena = response.Datos;
                } else {
                    console.log(response.Mensaje);
                }
            });
        };
    }

    module.controller('TipoColeccionController', TipoColeccionController);

})(angular.module('EpisApp'));