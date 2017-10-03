(function (module) {

    PublicacionFactory.$inject = ['BaseFactory'];

    function PublicacionFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarPublicacion = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarPublicacion', modelo);
        };

        SitioController.ObtenerPublicaciones = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerPublicaciones');
        };

        return SitioController;
    }

    module.factory('PublicacionFactory', PublicacionFactory);

})(angular.module("EpisApp"));