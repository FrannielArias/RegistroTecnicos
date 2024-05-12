using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    [Required(ErrorMessage = "El campo {0} es Requerido.")]
    public int TecnicosId { get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido.")]
    public string? Nombre{ get; set; }
    [Required(ErrorMessage = "El campo {0} es Requerido.")]
    public double SueldoHora{  get; set; }

}
