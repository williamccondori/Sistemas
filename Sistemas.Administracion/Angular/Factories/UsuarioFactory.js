(function (module) {

    UsuarioFactory.$inject = ['BaseFactory'];

    function UsuarioFactory(BaseFactory) {

        var UsuarioController = [];

        UsuarioController.GuardarUsuario = function (modelo) {
            return BaseFactory.Guardar('/Usuario/GuardarUsuario', modelo);
        };

        UsuarioController.ObtenerUsuarios = function () {
            return BaseFactory.Obtener('/Usuario/ObtenerUsuarios', );
        };

        return UsuarioController;
    }

    module.factory('UsuarioFactory', UsuarioFactory);

})(angular.module("EpisApp"));