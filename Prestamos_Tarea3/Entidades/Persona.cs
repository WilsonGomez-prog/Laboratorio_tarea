using System;
using System.ComponentModel.DataAnnotations;

namespace Prestamos_Tarea3.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public double Balance { get; set; }
    }
}