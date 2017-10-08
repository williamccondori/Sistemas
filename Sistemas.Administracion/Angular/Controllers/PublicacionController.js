(function (module) {

    PublicacionController.$inject = [
        '$scope',
        'alertify',
        'PublicacionFactory',
        'TipoPublicacionFactory'
    ];

    function PublicacionController($scope, alertify, PublicacionFactory, TipoPublicacionFactory) {

        alertify
            .okBtn("Si")
            .cancelBtn("No");

        $scope.TiposPublicacion = [];
        $scope.Publicaciones = [];

        $scope.Iniciar = function () {
            $scope.IniciarPublicacion();
            $scope.ObtenerTiposPublicacion();
            $scope.ObtenerPublicaciones();
        };

        $scope.TextoBotonGuardar = function () {
            return $scope.Formulario === EstadoFormulario.Modificar ? 'Modificar' : 'Crear';
        };

        $scope.IniciarPublicacion = function (publicacion) {
            if (!publicacion) {
                $scope.Publicacion = {
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.Publicacion = publicacion;
            }
        };

        $scope.CrearPublicacion = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarPublicacion();
            $scope.Publicacion.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalPublicacion");
        };

        $scope.ModificarPublicacion = function (publicacion) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarPublicacion(publicacion);
            $scope.Publicacion.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalPublicacion");
        };

        $scope.EliminarPublicacion = function (publicacion) {
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarPublicacion(publicacion);
                $scope.Publicacion.Estado = EstadoObjeto.Borrado;
                $scope.GuardarPublicacion();
            });
        };

        $scope.CerrarPublicacion = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalPublicacion");
            });
        };

        $scope.GuardarPublicacion = function () {
            Bootstrap.CerrarModal("#ModalPublicacion");
            PublicacionFactory.GuardarPublicacion($scope.Publicacion).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerPublicaciones();
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

        $scope.ObtenerPublicaciones = function () {
            PublicacionFactory.ObtenerPublicaciones().then(function (response) {
                if (response.Estado) {
                    $scope.Publicaciones = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };
    }
    module.controller('PublicacionController', PublicacionController);

})(angular.module('EpisApp'));