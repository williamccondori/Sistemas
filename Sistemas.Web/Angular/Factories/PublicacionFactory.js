(function (module) {

    PublicacionFactory.$inject = ['BaseFactory'];

    function PublicacionFactory(BaseFactory) {

        var PublicacionController = [];
        
        PublicacionController.ObtenerPublicaciones = function () {
            return BaseFactory.Obtener('/Publicacion/ObtenerPublicaciones');
        };

        return  PublicacionController;
    }

    module.factory('PublicacionFactory', PublicacionFactory);

})(angular.module("EpisApp"));