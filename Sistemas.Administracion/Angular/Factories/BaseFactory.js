(function (module) {

    BaseFactory.$inject = ['$resource'];

    function BaseFactory($resource) {

        var servicio = [];

        servicio.Obtener = function (ruta) {
            return $resource(ruta, {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post().$promise;
        };

        servicio.Buscar = function (ruta, modelo) {
            return $resource(ruta, {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post(modelo).$promise;
        };

        servicio.Guardar = function (ruta, modelo) {
            return $resource(ruta, {}, {
                Post: {
                    method: 'POST',
                    isArray: false
                }
            }).Post(modelo).$promise;
        };

        servicio.Eliminar = function (ruta, modelo) {
            return $resource(ruta, {}, {
                Delete: {
                    method: 'DELETE',
                    isArray: false
                }
            }).Delete(modelo).$promise;
        };

        return servicio;
    }

    module.factory('BaseFactory', BaseFactory);

})(angular.module("EpisApp"));