using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    [Required(ErrorMessage = "El campo {0} es Requerido.")]
    public int TecnicosId { get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "No se permiten caracteres especiales")]
    public string? Nombre{ get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido.")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El sueldo solo puede contener dígitos.")]
    [Range(minimum: 0.1, maximum: 10000000000000000000, ErrorMessage = "El monto debe ser mayor a 0 o es demasiado alto para el sistema")]
    public double SueldoHora{  get; set; }

    [ForeignKey("TipoId")]
    public int TipoId {  get; set; }

}
