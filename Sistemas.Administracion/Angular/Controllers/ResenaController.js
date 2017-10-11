(function (module) {

    ResenaController.$inject = [
        '$scope',
        'alertify',
        'ResenaFactory',
        'TipoResenaFactory',
        'AutorResenaFactory'
    ];

    function ResenaController($scope, alertify, ResenaFactory, TipoResenaFactory, AutorResenaFactory) {

        alertify.okBtn("Si").cancelBtn("No");

        $scope.TiposResena = [];
        $scope.Resenas = [];

        $scope.Iniciar = function () {
            $scope.IniciarResena();
            $scope.ObtenerTiposResena();
            $scope.ObtenerAutoresResena();
            $scope.ObtenerResenas();
        };

        $scope.TextoBotonGuardar = function () {
            return $scope.Formulario === EstadoFormulario.Modificar ? 'Modificar' : 'Crear';
        };

        $scope.IniciarResena = function (Resena) {
            if (!Resena) {
                $scope.Resena = {
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.Resena = Resena;
            }
        };

        $scope.CrearResena = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarResena();
            $scope.Resena.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalResena");
        };

        $scope.ModificarResena = function (Resena) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarResena(Resena);
            $scope.Resena.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalResena");
        };

        $scope.EliminarResena = function (Resena) {
            alertify.confirm(MensajeConfirmacion.Eliminar, function () {
                $scope.Formulario = EstadoFormulario.Eliminar;
                $scope.IniciarResena(Resena);
                $scope.Resena.Estado = EstadoObjeto.Borrado;
                $scope.GuardarCambios();
            });
        };

        $scope.CerrarResena = function () {
            alertify.confirm(MensajeConfirmacion.Cancelar, function () {
                Bootstrap.CerrarModal("#ModalResena");
            });
        };

        $scope.GuardarResena = function () {
            alertify.confirm(MensajeConfirmacion.Guardar, function () {
                Bootstrap.CerrarModal("#ModalResena");
                $scope.GuardarCambios();
            });
        };
        
        $scope.ObtenerTiposResena = function () {
            TipoResenaFactory.ObtenerTiposResena().then(function (response) {
                if (response.Estado) {
                    $scope.TiposResena = response.Datos;
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

        $scope.ObtenerResenas = function () {
            ResenaFactory.ObtenerResenas().then(function (response) {
                if (response.Estado) {
                    $scope.Resenas = response.Datos;
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };

        $scope.GuardarCambios = function () {
            ResenaFactory.GuardarResena($scope.Resena).then(function (response) {
                if (response.Estado) {
                    alertify.success(MensajeRespuesta.Exito.Descripcion);
                    $scope.ObtenerResenas();
                } else {
                    alertify.error(response.Mensaje);
                }
            });
        };
    }
    module.controller('ResenaController', ResenaController);

})(angular.module('EpisApp'));