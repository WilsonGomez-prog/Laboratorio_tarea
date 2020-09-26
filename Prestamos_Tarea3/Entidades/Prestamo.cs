using System;
using System.ComponentModel.DataAnnotations;

namespace Prestamos_Tarea3.Entidades
{
    public class Prestamo
    {   
        [Key]
        public int PrestamoId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public int PersonaId { get; set; }
        public string Concepto { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}