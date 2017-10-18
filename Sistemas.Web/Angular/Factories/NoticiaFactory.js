(function (module) {

    NoticiaFactory.$inject = ['BaseFactory'];

    function NoticiaFactory(BaseFactory) {

        var NoticiaController = [];
        
        NoticiaController.ObtenerNoticias = function () {
            return BaseFactory.Obtener('/Noticia/ObtenerNoticias');
        };

        NoticiaController.BuscarNoticia = function (idPublicacion) {
            return BaseFactory.Buscar('/Noticia/BuscarNoticia', { idPublicacion: idPublicacion});
        };

        return  NoticiaController;
    }

    module.factory('NoticiaFactory', NoticiaFactory);

})(angular.module("EpisApp"));