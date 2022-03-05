using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.AreasViewModel
{
    public class DeleteAreaRequest
    {
        [Display(Name = "Código área")]
        public int IdArea { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
