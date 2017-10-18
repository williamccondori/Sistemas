(function (module) {

    ActualidadController.$inject = [
        '$scope',
        'ActualidadFactory'
    ];

    function ActualidadController($scope, ActualidadFactory) {

        $scope.Actualidades = [];

        $scope.Iniciar = function () {
            $scope.ObtenerActualidades();
        };

        $scope.ObtenerActualidades = function () {
            ActualidadFactory.ObtenerActualidades().then(function (response) {
                if (response.Estado) {
                    
                    $scope.Actualidades = response.Datos;

                    var actualidadesTotales = $scope.Actualidades.length;
                    var actualidadesPrincipales = 6;

                    $scope.ActualidadesPrincipal = $scope.Actualidades.slice(0, actualidadesPrincipales);
                    $scope.ActualidadesSecundario = $scope.Actualidades.slice(actualidadesPrincipales, actualidadesTotales);

                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

    }
    module.controller('ActualidadController', ActualidadController);

})(angular.module('EpisApp'));