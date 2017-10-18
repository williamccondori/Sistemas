(function (module) {

    ComunicadoFactory.$inject = ['BaseFactory'];

    function ComunicadoFactory(BaseFactory) {

        var ComunicadoController = [];
        
        ComunicadoController.ObtenerComunicados = function () {
            return BaseFactory.Obtener('/Comunicado/ObtenerComunicados');
        };

        return  ComunicadoController;
    }

    module.factory('ComunicadoFactory', ComunicadoFactory);

})(angular.module("EpisApp"));