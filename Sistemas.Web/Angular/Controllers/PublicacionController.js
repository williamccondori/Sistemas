(function (module) {

    PublicacionController.$inject = [
        '$scope',
        'PublicacionFactory'
    ];

    function PublicacionController($scope, PublicacionFactory) {

        $scope.Publicaciones = [];

        $scope.Iniciar = function () {
            $scope.ObtenerPublicaciones();
        };

        $scope.ObtenerPublicaciones = function () {
            PublicacionFactory.ObtenerPublicaciones().then(function (response) {
                if (response.Estado) {
                    
                    $scope.Publicaciones = response.Datos;

                    var PublicacionesTotales = $scope.Publicaciones.length;
                    var PublicacionesPrincipales = 6;

                    $scope.PublicacionesPrincipal = $scope.Publicaciones.slice(0, PublicacionesPrincipales);
                    $scope.PublicacionesSecundario = $scope.Publicaciones.slice(PublicacionesPrincipales, PublicacionesTotales);

                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

    }
    module.controller('PublicacionController', PublicacionController);

})(angular.module('EpisApp'));