(function (module) {

    PublicacionController.$inject = [
        '$scope'
    ];

    function PublicacionController($scope) {

        $scope.Publicaciones = [];

        $scope.Iniciar = function () {
            $scope.IniciarPublicacion();
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
            //$scope.GuardarResena();
        };

        $scope.CerrarPublicacion = function () {
            Bootstrap.CerrarModal("#ModalPublicacion");
        };

        $scope.GuardarPublicacion = function () {
            Bootstrap.CerrarModal("#ModalPublicacion");
            $scope.Publicaciones.push($scope.Publicacion);
        };
    }
    module.controller('PublicacionController', PublicacionController);

})(angular.module('EpisApp'));