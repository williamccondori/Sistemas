(function (module) {

    GradoAcademicoFactory.$inject = ['BaseFactory'];

    function GradoAcademicoFactory(BaseFactory) {

        var SitioController = [];

        SitioController.GuardarGradoAcademico = function (modelo) {
            return BaseFactory.Guardar('/Sitio/GuardarGradoAcademico', modelo);
        };

        SitioController.ObtenerGradosAcademicos = function () {
            return BaseFactory.Obtener('/Sitio/ObtenerGradosAcademicos', );
        };

        return SitioController;
    }

    module.factory('GradoAcademicoFactory', GradoAcademicoFactory);

})(angular.module("EpisApp"));