using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.AreasViewModel
{
    public class CreateAreaRequest
    {
        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "Solo se permite un máximo de 100 carácteres")]
        [Required]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(2000, ErrorMessage = "Solo se permite un máximo de 2000 carácteres")]
        [Required]
        public string Descripcion { get; set; }
    }
}
