(function (module) {

    PublicacionController.$inject = [
        '$scope',
        'PublicacionFactory',
        'TipoPublicacionFactory'
    ];

    function PublicacionController($scope, PublicacionFactory, TipoPublicacionFactory) {

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
            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarPublicacion(publicacion);
            $scope.Publicacion.Estado = EstadoObjeto.Borrado;
            $scope.GuardarPublicacion();
        };

        $scope.CerrarPublicacion = function () {
            Bootstrap.CerrarModal("#ModalPublicacion");
        };

        $scope.GuardarPublicacion = function () {
            Bootstrap.CerrarModal("#ModalPublicacion");
            PublicacionFactory.GuardarPublicacion($scope.Publicacion).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerPublicaciones();
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

        $scope.ObtenerPublicaciones = function () {
            PublicacionFactory.ObtenerPublicaciones().then(function (response) {
                if (response.Estado) {
                    $scope.Publicaciones = response.Datos;
                } else {
                    console.log(response.Mensaje);
                }
            });
        };
    }
    module.controller('PublicacionController', PublicacionController);

})(angular.module('EpisApp'));