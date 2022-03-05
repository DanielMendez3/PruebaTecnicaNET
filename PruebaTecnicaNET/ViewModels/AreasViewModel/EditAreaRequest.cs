using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.AreasViewModel
{
    public class EditAreaRequest
    {
        public int IdArea { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "Solo se permite un máximo de 100 carácteres")]
        [Required(ErrorMessage = "El campo Nombre no puede quedar vacío")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(2000, ErrorMessage = "Solo se permite un máximo de 2000 carácteres")]
        [Required(ErrorMessage = "El campo Decripción no puede quedar vacío")]
        public string Descripcion { get; set; }
    }
}
