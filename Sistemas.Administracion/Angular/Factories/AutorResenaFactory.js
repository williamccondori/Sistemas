(function (module) {

    AutorResenaFactory.$inject = ['BaseFactory'];

    function AutorResenaFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarAutorResena = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarAutorResena', modelo);
        };

        SitioController.ObtenerAutoresResena = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerAutoresResena', );
        };

        return SitioController;
    }

    module.factory('AutorResenaFactory', AutorResenaFactory);

})(angular.module("EpisApp"));