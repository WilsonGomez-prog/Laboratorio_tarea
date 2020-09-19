

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class PersonasBLL
{

    /// <summary>
    /// Permite guardar(modificar/insertar) una entidad(Persona) en la base de datos, verificando si ya existia o si es nueva.
    ///</summary>
    ///<param name ="persona">Es la entidad(Persona) que se desea insertar.</param>
    public static bool Guardar(Personas persona)
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
    /// Permite insertar una entidad(Persona) en la base de datos.
    ///</summary>
    ///<param name ="persona">Es la entidad(Persona) que se desea insertar.</param>
    private static bool Insertar(Personas persona)
    {
        Contexto contexto = new Contexto();
        bool insertado = false;

        try
        {
            contexto.Personas.Add(persona);
            insertado  = contexto.SaveChanges() > 0;
        }
        catch(Exception)
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
    ///</summary>
    ///<param name ="persona">Es la entidad(Persona) que se desea modificar.</param>
    private static bool Modificar(Personas persona)
    {
        Contexto contexto = new Contexto();
        bool modificado = false;

        try
        {
            contexto.Entry(persona).State = EntityState.Modified;
            modificado  = contexto.SaveChanges() > 0;
        }
        catch(Exception)
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
    /// Permite buscar una entidad(Persona) en la base de datos.
    ///</summary>
    ///<param name ="id"> Es el ID de la entidad(Persona) que desea buscar</param>
    public static Personas Buscar(int id)
    {
        Contexto contexto = new Contexto();
        Personas persona;

        try
        {
            persona = contexto.Personas.Find(id);
        }
        catch(Exception)
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
    ///</summary>
    ///<param name ="id"> Es el ID de la entidad(Persona) que desea buscar</param>
    public static bool Eliminar(int id)
    {
        Contexto contexto = new Contexto();
        bool eliminado = false;

        try
        {
            var persona = contexto.Personas.Find(id);
            if(persona != null)
            {
                contexto.Personas.Remove(persona);
                eliminado = contexto.SaveChanges() > 0;
            }
        }
        catch(Exception)
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
    /// Permite verificar la existencia de una entidad(Persona) con ese ID en la base de datos.
    ///</summary>
    ///<param name ="id"> Es el ID de la entidad(Persona) que desea buscar</param>
    public static bool Existe(int id)
    {
        Contexto contexto = new Contexto();
        bool existe = false;

        try
        {
            existe = contexto.Personas.Any(e => e.PersonaId == id);
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return existe;
    }
}