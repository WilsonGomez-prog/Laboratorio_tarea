using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Prestamos_Tarea3.DAL;
using Prestamos_Tarea3.Entidades;

namespace Prestamos_Tarea3
{
    public class PersonaBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad(Persona) en la base de datos.
        /// </summary>
        /// <param name = "persona"> Es la entidad(Persona) que se desea Guardar.</param>
        public static bool Guardar(Persona persona)
        {
            if(!Existe(persona.PersonaId))
            {
                return Insertar(persona);
            }
            else
            {
                return Modificar(persona);
            }
        }

        /// <summary>
        /// Permite buscar una entidad(Persona) en la base de datos.
        /// </summary>
        /// <param name = "personaId"> Es el ID de la entidad(Persona) que se desea encontrar.</param>
        public static Persona Buscar(int personaId)
        {
            Persona persona;
            Contexto contexto = new Contexto();

            try
            {
                persona = contexto.persona.Find(personaId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return persona;
        }

        /// <summary>
        /// Permite eliminar una entidad(Persona) en la base de datos.
        /// </summary>
        /// <param name = "personaId"> Es el ID de la entidad(Persona) que se desea eliminar de la base de datos.</param>
        public static bool Eliminar(int personaId)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var persona = contexto.persona.Find(personaId);

                if (persona != null)
                {
                    contexto.persona.Remove(persona);
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
        /// Permite insertar una entidad(Persona) en la base de datos.
        /// </summary>
        /// <param name = "persona"> Es la entidad(Persona) que se desea insertar.</param>
        private static bool Insertar(Persona persona)
        {
            bool insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Add(persona);
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
        /// Permite modificar una entidad(Persona) en la base de datos.
        /// </summary>
        /// <param name = "persona"> Es la entidad(Persona) que se desea modificar.</param>
        private static bool Modificar(Persona persona)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
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
        /// Permite verificar la existencia de una entidad(Persona) en la base de datos.
        /// </summary>
        /// <param name = "personaId"> Es el ID de la entidad(Persona) de la cual se desea verificar la existencia.</param>
        public static bool Existe(int personaId)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.prestamo.Any(e => e.PersonaId == personaId);
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