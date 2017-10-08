(function (module) {

    CaracteristicaController.$inject = [
        '$scope',
        'alertify',
        'GradoAcademicoFactory',
        'AutorResenaFactory'
    ];

    function CaracteristicaController($scope, alertify, GradoAcademicoFactory, AutorResenaFactory) {

        alertify
            .okBtn("Aceptar")
            .cancelBtn("Cancelar");

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
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarGradoAcademico(gradoAcademico);
                $scope.GradoAcademico.Estado = EstadoObjeto.Borrado;
                $scope.GuardarGradoAcademico();
            });
        };

        $scope.CerrarGradoAcademico = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalGradoAcademico");
            });
        };

        $scope.GuardarGradoAcademico = function () {
            Bootstrap.CerrarModal("#ModalGradoAcademico");
            GradoAcademicoFactory.GuardarGradoAcademico($scope.GradoAcademico).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerGradosAcademicos();
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.ObtenerGradosAcademicos = function () {
            GradoAcademicoFactory.ObtenerGradosAcademicos().then(function (response) {
                if (response.Estado) {
                    $scope.GradosAcademicos = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
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
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarAutorResena(autorResena);
                $scope.AutorResena.Estado = EstadoObjeto.Borrado;
                $scope.GuardarAutorResena();
            });
        };

        $scope.CerrarAutorResena = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalAutorResena");
            });
        };

        $scope.GuardarAutorResena = function () {
            Bootstrap.CerrarModal("#ModalAutorResena");
            AutorResenaFactory.GuardarAutorResena($scope.AutorResena).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerAutoresResena();
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.ObtenerAutoresResena = function () {
            AutorResenaFactory.ObtenerAutoresResena().then(function (response) {
                if (response.Estado) {
                    $scope.AutoresResena = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };
    }
    module.controller('CaracteristicaController', CaracteristicaController);

})(angular.module('EpisApp'));