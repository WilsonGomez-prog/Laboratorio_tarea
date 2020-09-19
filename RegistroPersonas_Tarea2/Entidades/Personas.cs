
using System;
using System.ComponentModel.DataAnnotations;

public class Personas
{
    [Key]
    public int PersonaId { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Cedula { get; set; }
    public string Direccion { get; set; }
    public DateTime Nacimiento { get; set; }
}