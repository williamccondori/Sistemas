﻿using Sistemas.Utilidades.Excepciones;
using System;

namespace Sistemas.Datos.Shared
{
    public class BaseRepository
    {
        protected void Guardar(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception excepcion)
            {
                if (excepcion.InnerException == null)
                    throw new Exception(excepcion.Message);

                if (excepcion.InnerException.InnerException == null)
                    throw new Exception(excepcion.InnerException.Message);

                throw new Exception(excepcion.InnerException.InnerException.Message);
            }
        }

        protected T Consultar<T>(Func<T> funcion)
        {
            try
            {
                return funcion();
            }
            catch (Exception excepcion)
            {
                if (excepcion.InnerException == null)
                    throw new Exception(excepcion.Message);

                if (excepcion.InnerException.InnerException == null)
                    throw new Exception(excepcion.InnerException.Message);

                throw new Exception(excepcion.InnerException.InnerException.Message);
            }
        }

        protected void Eliminar(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception)
            {
                throw new DeleteException();
            }
        }
    }
}
