(function (module) {

    ActualidadFactory.$inject = ['BaseFactory'];

    function ActualidadFactory(BaseFactory) {

        var ActualidadController = [];
        
        ActualidadController.ObtenerActualidades = function () {
            return BaseFactory.Obtener('/Actualidad/ObtenerActualidades');
        };

        return  ActualidadController;
    }

    module.factory('ActualidadFactory', ActualidadFactory);

})(angular.module("EpisApp"));