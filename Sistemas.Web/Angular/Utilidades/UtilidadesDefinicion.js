var EnvioHttp = {
    Get: "GET",
    Post: "POST"
};

var MensajeConfirmacion = {
    Guardar: "¿Desea guardar los cambios?",
    Eliminar: "¿Desea eliminar este registro?",
    Cancelar: "¿Desea cancelar y deshacer los cambios?",
    Aceptar: "¿Desea aceptar el documento?",
    Devolver: "¿Desea devolver el documento?"
};

var MensajeRespuesta = {
    Exito: {
        Titulo: 'CORRECTO!',
        Descripcion: 'El proceso se ha completado correctamente'
    },
    Advertencia: {
        Titulo: 'ADVERTENCIA!',
        Descripcion: 'La operación está proceso'
    },
    Error: {
        Titulo: 'ERROR!',
        Descripcion: 'Se ha encontrado un error al realizar el proceso'
    }
};

var EstadoObjeto = {
    SinCambios: 0,
    Nuevo: 1,
    Modificado: 2,
    Borrado: 3
};

var EstadoFormulario = {
    Predeterminado: 0,
    Crear: 1,
    Modificar: 2,
    Eliminar: 3
};