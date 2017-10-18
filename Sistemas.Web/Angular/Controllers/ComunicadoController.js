(function (module) {

    ComunicadoController.$inject = [
        '$scope',
        'ComunicadoFactory'
    ];

    function ComunicadoController($scope, ComunicadoFactory) {

        $scope.Comunicados = [];

        $scope.Iniciar = function () {
            $scope.ObtenerComunicados();
        };

        $scope.ObtenerComunicados = function () {
            ComunicadoFactory.ObtenerComunicados().then(function (response) {
                if (response.Estado) {
                    
                    $scope.Comunicados = response.Datos;

                    var ComunicadosTotales = $scope.Comunicados.length;
                    var ComunicadosPrincipales = 6;

                    $scope.ComunicadosPrincipal = $scope.Comunicados.slice(0, ComunicadosPrincipales);
                    $scope.ComunicadosSecundario = $scope.Comunicados.slice(ComunicadosPrincipales, ComunicadosTotales);

                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

    }
    module.controller('ComunicadoController', ComunicadoController);

})(angular.module('EpisApp'));