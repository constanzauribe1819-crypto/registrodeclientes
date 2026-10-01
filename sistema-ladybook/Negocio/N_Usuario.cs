using System;
using System.Collections.Generic;
using sistema-ladybook.Datos;   // Namespace de tu capa de datos

namespace sistema-ladybook.Negocio
{
    public class N_Usuario
    {
        private readonly bd_usuario datosUsuario;

        public N_Usuario()
        {
            datosUsuario = new bd_usuario();
        }

        // 1. Obtener todos los registros de clientes
        public List<RegistroCliente> ObtenerTodosLosRegistros()
        {
            try
            {
                return datosUsuario.ObtenerTodosLosRegistros();
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error en un archivo de log si lo deseas
                throw new Exception("Error al obtener los registros en la capa de negocio: " + ex.Message);
            }
        }

        // 2. Obtener registros filtrados por tipo de registro con validación
        public List<RegistroCliente> ObtenerRegistrosPorTipo(string tipoRegistro)
        {
            if (string.IsNullOrWhiteSpace(tipoRegistro))
            {
                throw new ArgumentException("El tipo de registro no puede estar vacío o nulo.", nameof(tipoRegistro));
            }

            try
            {
                return datosUsuario.ObtenerRegistrosPorTipo(tipoRegistro.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar registros por tipo: " + ex.Message);
            }
        }

        // 3. Guardar / Insertar un nuevo registro con validaciones de negocio
        public bool GuardarRegistro(RegistroCliente registro)
        {
            ValidarRegistroCliente(registro);

            try
            {
                return datosUsuario.GuardarRegistro(registro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el registro: " + ex.Message);
            }
        }

        // 4. Actualizar un registro existente con validaciones
        public bool ActualizarRegistro(RegistroCliente registro)
        {
            if (registro == null || registro.IdRegistro <= 0)
            {
                throw new ArgumentException("El ID del registro es inválido para la actualización.");
            }

            ValidarRegistroCliente(registro);

            try
            {
                return datosUsuario.ActualizarRegistro(registro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el registro: " + ex.Message);
            }
        }

        // 5. Eliminar un registro por su ID con validación
        public bool EliminarRegistro(int idRegistro)
        {
            if (idRegistro <= 0)
            {
                throw new ArgumentException("El ID de registro proporcionado no es válido.");
            }

            try
            {
                return datosUsuario.EliminarRegistro(idRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el registro: " + ex.Message);
            }
        }

        // 6. Obtener resultados de auditoría del log
        public List<LogRegistroClienteDTO> ObtenerHistóricoMovimientos()
        {
            try
            {
                return datosUsuario.ObtenerHistóricoMovimientos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el histórico de movimientos: " + ex.Message);
            }
        }

        #region Métodos Auxiliares de Validación Privados

        private void ValidarRegistroCliente(RegistroCliente registro)
        {
            if (registro == null)
            {
                throw new ArgumentNullException(nameof(registro), "El objeto del registro no puede ser nulo.");
            }

            if (registro.IdCliente <= 0)
            {
                throw new ArgumentException("Debe asociar un ID de cliente válido.");
            }

            if (string.IsNullOrWhiteSpace(registro.TipoRegistro))
            {
                throw new ArgumentException("El tipo de registro es obligatorio.");
            }

            if (registro.Precio < 0)
            {
                throw new ArgumentException("El precio no puede ser un valor negativo.");
            }
        }

        #endregion
    }
}