(function (module) {

    CaracteristicaController.$inject = [
        '$scope',
        'GradoAcademicoFactory',
        'AutorResenaFactory'
    ];

    function CaracteristicaController($scope, GradoAcademicoFactory, AutorResenaFactory) {

        $scope.GradosAcademicos = [];
        $scope.AutoresResena = [];

        $scope.Iniciar = function () {
            $scope.Formulario = EstadoFormulario.SinCambios;
            $scope.IniciarGradoAcademico();
            $scope.IniciarAutorResena();
            $scope.ObtenerGradosAcademicos();
            $scope.ObtenerAutoresResena();
        };

        $scope.TextoBotonGuardar = function () {
            return $scope.Formulario === EstadoFormulario.Modificar ? 'Modificar' : 'Crear';
        };

        /**
         * Grados académicos
         */

        $scope.IniciarGradoAcademico = function (gradoAcademico) {
            if (!gradoAcademico) {
                $scope.GradoAcademico = {
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.GradoAcademico = gradoAcademico;
            }
        };

        $scope.CrearGradoAcademico = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarGradoAcademico();
            $scope.GradoAcademico.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalGradoAcademico");
        };

        $scope.ModificarGradoAcademico = function (gradoAcademico) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarGradoAcademico(gradoAcademico);
            $scope.GradoAcademico.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalGradoAcademico");
        };

        $scope.EliminarGradoAcademico = function (gradoAcademico) {
            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarGradoAcademico(gradoAcademico);
            $scope.GradoAcademico.Estado = EstadoObjeto.Borrado;
            $scope.GuardarResena();
        };

        $scope.CerrarGradoAcademico = function () {
            Bootstrap.CerrarModal("#ModalGradoAcademico");
        };

        $scope.GuardarGradoAcademico = function () {
            Bootstrap.CerrarModal("#ModalGradoAcademico");
            GradoAcademicoFactory.GuardarGradoAcademico($scope.GradoAcademico).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerGradosAcademicos();
                } else {
                    console.log(response.Mensaje);
                }
            });
        };

        $scope.ObtenerGradosAcademicos = function () {
            GradoAcademicoFactory.ObtenerGradosAcademicos().then(function (response) {
                if (response.Estado) {
                    $scope.GradosAcademicos = response.Datos;
                } else {
                    console.log(response.Mensaje);
                }
            });
        };

        /**
         * Autores de reseña
         */

        $scope.IniciarAutorResena = function (autorResena) {
            if (!autorResena) {
                $scope.AutorResena = {
                    IdGradoAcademico: null,
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.AutorResena = autorResena;
            }
        };

        $scope.CrearAutorResena = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarAutorResena();
            $scope.AutorResena.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalAutorResena");
        };

        $scope.ModificarAutorResena = function (autorResena) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarAutorResena(autorResena);
            $scope.AutorResena.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalAutorResena");
        };

        $scope.EliminarAutorResena = function (autorResena) {
            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarAutorResena(autorResena);
            $scope.AutorResena.Estado = EstadoObjeto.Borrado;
            $scope.GuardarAutorResena();
        };

        $scope.CerrarAutorResena = function () {
            Bootstrap.CerrarModal("#ModalAutorResena");
        };

        $scope.GuardarAutorResena = function () {
            Bootstrap.CerrarModal("#ModalAutorResena");
            AutorResenaFactory.GuardarAutorResena($scope.AutorResena).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerAutoresResena();
                } else {
                    console.log(response.Mensaje);
                }
            });
        };

        $scope.ObtenerAutoresResena = function () {
            AutorResenaFactory.ObtenerAutoresResena().then(function (response) {
                if (response.Estado) {
                    $scope.AutoresResena = response.Datos;
                } else {
                    console.log(response.Mensaje);
                }
            });
        };
    }
    module.controller('CaracteristicaController', CaracteristicaController);

})(angular.module('EpisApp'));