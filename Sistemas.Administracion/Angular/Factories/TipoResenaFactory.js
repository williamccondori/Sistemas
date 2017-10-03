(function (module) {

    TipoResenaFactory.$inject = ['BaseFactory'];

    function TipoResenaFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarTipoResena = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarTipoResena', modelo);
        };

        SitioController.ObtenerTiposResena = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerTiposResena', );
        };

        return SitioController;
    }

    module.factory('TipoResenaFactory', TipoResenaFactory);

})(angular.module("EpisApp"));