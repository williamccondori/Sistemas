(function (module) {

    ResenaFactory.$inject = ['BaseFactory'];

    function ResenaFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarResena = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarResena', modelo);
        };

        SitioController.ObtenerResenas = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerResenas');
        };

        return SitioController;
    }

    module.factory('ResenaFactory', ResenaFactory);

})(angular.module("EpisApp"));