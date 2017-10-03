(function (module) {

    TipoPublicacionFactory.$inject = ['BaseFactory'];

    function TipoPublicacionFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarTipoPublicacion = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarTipoPublicacion', modelo);
        };

        SitioController.ObtenerTiposPublicacion = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerTiposPublicacion', );
        };

        return SitioController;
    }

    module.factory('TipoPublicacionFactory', TipoPublicacionFactory);

})(angular.module("EpisApp"));