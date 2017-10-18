(function (module) {

    function Fecha() {
        var formatoFecha = /\/Date\(([0-9]*)\)\//;
        return function (fechaJson) {
            var fecha = fechaJson.match(formatoFecha);
            if (fecha)
                return new Date(parseInt(fecha[1]));
            else
                return null;
        };
    }

    module.filter('Fecha', Fecha);

})(angular.module('EpisApp'));