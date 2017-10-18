(function (module) {

    function Texto($sce) {
        return function (valor) {
            return $sce.trustAsHtml(valor);
        };
    }

    module.filter('Texto', Texto);

})(angular.module('EpisApp'));