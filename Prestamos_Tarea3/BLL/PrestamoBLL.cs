using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Prestamos_Tarea3.Entidades;
using Prestamos_Tarea3.DAL;

namespace Prestamos_Tarea3
{
    public class PrestamoBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad(Prestamo) en la base de datos.
        /// </summary>
        /// <param name = "prestamo"> Es la entidad(prestamo) que se desea Guardar.</param>
        public static bool Guardar(Prestamo prestamo)
        {
            if(!Existe(prestamo.PrestamoId))
            {
                return Insertar(prestamo);
            }
            else
            {
                return Modificar(prestamo);
            }
        }

        /// <summary>
        /// Permite buscar una entidad(Prestamo) en la base de datos.
        /// </summary>
        /// <param name = "prestamoId"> Es el ID de la entidad(prestamo) que se desea encontrar.</param>
        public static Prestamo Buscar(int prestamoId)
        {
            Prestamo prestamo;
            Contexto contexto = new Contexto();

            try
            {
                prestamo = contexto.prestamo.Find(prestamoId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        /// <summary>
        /// Permite eliminar una entidad(Prestamo) en la base de datos.
        /// </summary>
        /// <param name = "prestamoId"> Es el ID de la entidad(prestamo) que se desea eliminar de la base de datos.</param>
        public static bool Eliminar(int prestamoId)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.prestamo.Find(prestamoId);

                if (prestamo != null)
                {
                    contexto.prestamo.Remove(prestamo);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        /// <summary>
        /// Permite insertar una entidad(Prestamo) en la base de datos.
        /// </summary>
        /// <param name = "prestamo"> Es la entidad(prestamo) que se desea insertar.</param>
        private static bool Insertar(Prestamo prestamo)
        {
            bool insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(prestamo);
                insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return insertado;
        }

        /// <summary>
        /// Permite modificar una entidad(Prestamo) en la base de datos.
        /// </summary>
        /// <param name = "prestamo"> Es la entidad(prestamo) que se desea modificar.</param>
        private static bool Modificar(Prestamo prestamo)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(prestamo).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        /// <summary>
        /// Permite verificar la existencia de una entidad(prestamo) en la base de datos.
        /// </summary>
        /// <param name = "prestamoId"> Es el ID de la entidad(prestamo) de la cual se desea verificar la existencia.</param>
        public static bool Existe(int prestamoId)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.prestamo.Any(e => e.PrestamoId == prestamoId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}