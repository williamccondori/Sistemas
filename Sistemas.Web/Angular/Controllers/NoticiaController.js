(function (module) {

    NoticiaController.$inject = [
        '$scope',
        'NoticiaFactory'
    ];

    function NoticiaController($scope, NoticiaFactory) {

        $scope.Noticias = [];
        $scope.Noticia = {};

        $scope.Iniciar = function () {
            $scope.ObtenerNoticias();
        };

        $scope.IniciarDetalle = function (idPublicacion) {
            $scope.BuscarNoticia(idPublicacion);
        };

        $scope.ObtenerNoticias = function () {
            NoticiaFactory.ObtenerNoticias().then(function (response) {
                if (response.Estado) {
                    
                    $scope.Noticias = response.Datos;

                    var NoticiasTotales = $scope.Noticias.length;
                    var NoticiasPrincipales = 6;

                    $scope.NoticiasPrincipal = $scope.Noticias.slice(0, NoticiasPrincipales);
                    $scope.NoticiasSecundario = $scope.Noticias.slice(NoticiasPrincipales, NoticiasTotales);

                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.BuscarNoticia = function (idPublicacion) {
            NoticiaFactory.BuscarNoticia(idPublicacion).then(function (response) {
                if (response.Estado) {
                    $scope.Noticia = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

    }
    module.controller('NoticiaController', NoticiaController);

})(angular.module('EpisApp'));