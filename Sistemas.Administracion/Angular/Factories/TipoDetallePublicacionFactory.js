(function (module) {

    TipoDetallePublicacionFactory.$inject = ['BaseFactory'];

    function TipoDetallePublicacionFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarTipoDetallePublicacion = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarTipoDetallePublicacion', modelo);
        };

        SitioController.ObtenerTiposDetallePublicacion = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerTiposDetallePublicacion', );
        };

        return SitioController;
    }

    module.factory('TipoDetallePublicacionFactory', TipoDetallePublicacionFactory);

})(angular.module("EpisApp"));