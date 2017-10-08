(function (module) {

    UsuarioController.$inject = [
        '$scope',
        'alertify',
        'UsuarioFactory'
    ];

    function UsuarioController($scope, alertify, UsuarioFactory) {

        alertify
            .okBtn("Si")
            .cancelBtn("No");

        $scope.Usuarios = [];

        $scope.Iniciar = function () {
            $scope.IniciarUsuario();
            $scope.ObtenerUsuarios();
        };

        $scope.TextoBotonGuardar = function () {
            return $scope.Formulario === EstadoFormulario.Modificar ? 'Modificar' : 'Crear';
        };

        $scope.IniciarUsuario = function (usuario) {
            if (!usuario) {
                $scope.Usuario = {
                    Email: null,
                    Habilitado: true,
                    Estado: EstadoObjeto.SinCambios
                };
            } else {
                $scope.Usuario = usuario;
            }
        };

        $scope.CrearUsuario = function () {
            $scope.Formulario = EstadoFormulario.Crear;
            $scope.IniciarUsuario();
            $scope.Usuario.Estado = EstadoObjeto.Nuevo;
            Bootstrap.AbrirModal("#ModalUsuario");
        };

        $scope.ModificarUsuario = function (usuario) {
            $scope.Formulario = EstadoFormulario.Modificar;
            $scope.IniciarUsuario(usuario);
            $scope.Usuario.Estado = EstadoObjeto.Modificado;
            Bootstrap.AbrirModal("#ModalUsuario");
        };

        $scope.EliminarUsuario = function (usuario) {

            swal(
                {
                    title: "Are you sure?",
                    text: "You will not be able to recover this imaginary file!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!"
                },
                alert("Eliminar")
            );


            $scope.Formulario = EstadoFormulario.Eliminar;
            $scope.IniciarUsuario(usuario);
            $scope.Usuario.Estado = EstadoObjeto.Borrado;
            $scope.GuardarUsuario();
        };

        $scope.CerrarUsuario = function () {
            Bootstrap.CerrarModal("#ModalUsuario");
        };

        $scope.GuardarUsuario = function () {
            
            Bootstrap.CerrarModal("#ModalUsuario");

            UsuarioFactory.GuardarUsuario($scope.Usuario).then(function (response) {
                if (response.Estado) {
                    $scope.ObtenerUsuarios();
                } else {
                    swal("Error", response.Mensaje, "warning");
                }
            });
        };
        
        $scope.ObtenerUsuarios = function () {
            UsuarioFactory.ObtenerUsuarios().then(function (response) {
                if (response.Estado) {
                    $scope.Usuarios = response.Datos;
                } else {
                    console.log(response.Mensaje);
                }
            });
        };
    }

    module.controller('UsuarioController', UsuarioController);

})(angular.module('EpisApp'));