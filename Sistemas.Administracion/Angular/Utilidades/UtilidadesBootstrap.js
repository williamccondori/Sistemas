var Bootstrap = Bootstrap || {};

Bootstrap.AbrirModal = function (idModal) {
    $(idModal).modal({
        backdrop: 'static'
    });
};

Bootstrap.CerrarModal = function (idModal) {
    $(idModal).modal('hide');
};