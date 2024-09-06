using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class TipoTecnico
{
    [Key]
    public int TipoId {  get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Descripcion { get; set; }

}
